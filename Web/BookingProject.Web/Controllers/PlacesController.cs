    namespace BookingProject.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;

    using BookingProject.Data.Models;
    using BookingProject.Services.Data;
    using BookingProject.Web.ViewModels.Home;
    using BookingProject.Web.ViewModels.Places;
    using BookingProject.Web.ViewModels.Reservations;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

    public class PlacesController : Controller
    {
        private const int PlacesPerPage = 2;

        private readonly IPlacesService placesService;
        private readonly ICategoriesService categoriesService;
        private readonly ICitiesService citiesService;
        private readonly IExtrasService extrasService;
        private readonly UserManager<ApplicationUser> userManager;

        public PlacesController(
            IPlacesService placesService,
            ICategoriesService categoriesService,
            ICitiesService citiesService,
            IExtrasService extrasService,
            UserManager<ApplicationUser> userManager)
        {
            this.placesService = placesService;
            this.categoriesService = categoriesService;
            this.citiesService = citiesService;
            this.extrasService = extrasService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> ShowUserPlaces()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            IEnumerable<PlaceViewModel> places = this.placesService.GetAllByUser<PlaceViewModel>(user.Id).ToList();

            var viewModel = new ListPlaceViewModel
            {
                Places = places,
            };
            if (viewModel == null)
            {
                return this.NotFound();
            }

            foreach (var place in viewModel.Places)
            {
                if (place.Reviews.Count > 0)
                {
                    place.Rating = (int)place.Reviews.Select(x => x.Rating).Average();
                }
                else
                {
                    place.Rating = 0;
                }
            }

            return this.View(viewModel);
        }

        public async Task<IActionResult> Administration()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            if (!user.IsAdmin)
            {
                return this.NotFound();
            }

            IEnumerable<PlaceViewModel> places = this.placesService.GetAll<PlaceViewModel>().ToList();

            var viewModel = new ListPlaceViewModel
            {
                Places = places,
            };
            if (viewModel == null)
            {
                return this.NotFound();
            }

            foreach (var place in viewModel.Places)
            {
                if (place.Reviews.Count > 0)
                {
                    place.Rating = (int)place.Reviews.Select(x => x.Rating).Average();
                }
                else
                {
                    place.Rating = 0;
                }
            }

            return this.View(viewModel);
        }

        public IActionResult ShowAllPlaces(int? cityId, int? guestNumber, string? dates, string? sortBy, string? categoryName, int page = 1)
        {
            var cities = this.citiesService.GetAll<CityDropDownViewModel>();
            var numbers = Enumerable.Range(1, 30).ToList();
            IEnumerable<GuestNumberDropDownViewModel> guestNumbers = numbers.Select(x => new GuestNumberDropDownViewModel { Id = x, Name = x.ToString() });

            IEnumerable<PlaceViewModel> places = this.placesService.GetAll<PlaceViewModel>().ToList();

            if (dates != null)
            {
                string[] splitDates = dates.Split(" - ");
                DateTime startDate = DateTime.Parse(splitDates[0]);
                DateTime endDate = DateTime.Parse(splitDates[1]);
                places = places.Where(p => this.CheckDates(startDate, endDate, p.Reservations.OrderBy(r => r.StartDate).ToList()));
            }

            if (categoryName != null)
            {
                places = places.Where(x => x.CategoryName == categoryName);
            }

            if (cityId != null && cityId != 0)
            {
                places = places.Where(x => x.CityId == cityId);
            }

            if (guestNumber != null && guestNumber != 0)
            {
                places = places.Where(x => x.MaxGuest >= guestNumber);
            }

            if (sortBy != null && sortBy != "id")
            {
                if (sortBy == "desc")
                {
                    places = places.OrderBy(p => p.PriceByNight);
                } else
                {
                    places = places.OrderByDescending(p => p.PriceByNight);
                }
            }

            var viewModel = new ListPlaceViewModel
            {
                Places = places,
                Categories =
                   this.categoriesService.GetAll<IndexCategoryViewModel>(),
                Cities = cities,
                GuestNumbers = guestNumbers,
            };

            if (viewModel == null)
            {
                return this.NotFound();
            }

            foreach (var place in viewModel.Places)
            {
                if (place.Reviews.Count > 0)
                {
                    place.Rating = (int)place.Reviews.Select(x => x.Rating).Average();
                }
                else
                {
                    place.Rating = 0;
                }
            }

            //viewModel.CardPlaces = this.placesService.GetByCategoryId<CardPlaceViewModel>(viewModel.Id, PlacesPerPage, (page - 1) * PlacesPerPage);

            var count = viewModel.Places.Count(); //this.placesService.GetCountById(viewModel.Id);
            viewModel.PagesCount = (int)Math.Ceiling((double)count / PlacesPerPage);
            if (viewModel.PagesCount == 0)
            {
                viewModel.PagesCount = 1;
            }

            viewModel.CurrentPage = page;

            return this.View(viewModel);
        }

        public IActionResult GetById(int id, string dates)
        {
            var placeViewModel = this.placesService.GetById<PlaceViewModel>(id);
            if (placeViewModel == null)
            {
                return this.NotFound();
            }

            if (placeViewModel.Reviews.Count > 0)
            {
                placeViewModel.Rating = (int)placeViewModel.Reviews.Select(x => x.Rating).Average();
                List<string> reservedDays = new List<string>();
                DateTime now = DateTime.Now;
                foreach (var res in placeViewModel.Reservations)
                {
                    for (DateTime date = res.StartDate; date <= res.EndDate; date = date.AddDays(1))
                    {
                        reservedDays.Add(date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
                    }
                }

                placeViewModel.ReservedDays = JsonConvert.SerializeObject(reservedDays);
            }
            else
            {
                placeViewModel.Rating = 0;
                placeViewModel.ReservedDays = JsonConvert.SerializeObject(new List<string>());
            }

            return this.View(placeViewModel);
        }

        public IActionResult Create()
        {
            var categories = this.categoriesService.GetAll<CategoryDropDownViewModel>();
            var cities = this.citiesService.GetAll<CityDropDownViewModel>();
            var extras = this.extrasService.GetAll<ExtraViewModel>();
            var viewModel = new CreatePlaceInputModel
            {
                Categories = categories,
                Cities = cities,
                Extras = extras.ToList(),
            };
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreatePlaceInputModel input)
        {
           var user = await this.userManager.GetUserAsync(this.User);
           if (!this.ModelState.IsValid)
           {
               return this.View(input);
           }

           var placeId = await this.placesService.CreateAsync(
               input.Name,
               input.CategoryId,
               input.CityId,
               input.Address,
               input.Description,
               user.Id,
               input.PriceByNight,
               input.BedroomsNum,
               input.BathroomsNum,
               input.BedsNum,
               input.MaxGuest,
               input.Pets,
               input.Smoking,
               input.Extras,
               input.Images);
           this.TempData["InfoMessage"] = "Place created!";
           return this.RedirectToAction(nameof(this.GetById), new { id = placeId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var place = this.placesService.GetById<EditPlaceViewModel>(id);

            if (place == null || place.User.Id != user.Id)
            {
                return this.NotFound();
            }

            var categories = this.categoriesService.GetAll<CategoryDropDownViewModel>();
            var cities = this.citiesService.GetAll<CityDropDownViewModel>();
            var extras = this.extrasService.GetAll<ExtraViewModel>();
            foreach (var extra in extras)
            {
                var placeExtra = place.PlaceExtras.FirstOrDefault(x => x.Extra.Name == extra.Name);
                if (placeExtra != null)
                {
                    extra.IsSelected = true;
                }
            }

            var viewModel = new EditPlaceViewModel
            {
                Id = place.Id,
                Name = place.Name,
                CategoryId = place.CategoryId,
                CityId = place.CityId,
                Address = place.Address,
                Description = place.Description,
                PriceByNight = place.PriceByNight,
                BedroomsNum = place.BedroomsNum,
                BathroomsNum = place.BathroomsNum,
                MaxGuest = place.MaxGuest,
                BedsNum = place.BedsNum,
                User = place.User,
                Pets = place.Pets,
                Smoking = place.Smoking,
                Categories = categories,
                Cities = cities,
                Extras = extras.ToList(),
            };
            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, string name, string description, int bedroomsNum, int bathroomsNum, int priceByNight, int bedsNum, int maxGuest, bool pets, bool smoking, List<ExtraViewModel> extras)
        {
            var place = this.placesService.GetById<EditPlaceViewModel>(id);

            var placeId = await this.placesService.UpdateAsync(
                id, name, description, bedroomsNum, bathroomsNum, priceByNight, bedsNum, maxGuest, pets, smoking, extras);
            this.TempData["InfoMessage"] = "Place Updated!";
            return this.RedirectToAction(nameof(this.GetById), new { id = placeId });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var place = this.placesService.GetById<EditPlaceViewModel>(id);

            if (!user.IsAdmin)
            {
                return this.Forbid();
            }

            if (place == null)
            {
                return this.NotFound();
            }

            await this.placesService.DeleteById(id);

            return this.RedirectToAction(nameof(this.Administration));
        }

        private bool CheckDates(DateTime start, DateTime end, List<Reservation> reservations)
        {
            if (reservations.Count == 0)
            {
                return true;
            }

            if (end < reservations.First().StartDate || start > reservations.Last().EndDate)
            {
                return true;
            }

            for (int i = 0; i < reservations.Count; i++)
            {
                DateTime resEnd = reservations[i].EndDate;
                try
                {
                    var nextRes = reservations[i + 1];
                    if (resEnd < start && end < nextRes.StartDate)
                    {
                        return true;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return false;
        }
    }
}
