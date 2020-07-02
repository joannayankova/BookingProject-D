namespace BookingProject.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using BookingProject.Data.Models;
    using BookingProject.Services.Data;
    using BookingProject.Web.ViewModels.Places;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

    public class PlacesController : Controller
    {
        private readonly IPlacesService placesService;
        private readonly ICategoriesService categoriesService;
        private readonly ICitiesService citiesService;
        private readonly IExtrasService extrasService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;

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

        public IActionResult ShowAllPlaces()
        {
            var viewModel = new ListPlaceViewModel
            {
                CardsPlaces =
                   this.placesService.GetAll<CardPlaceViewModel>().ToList(),
            };
            if (viewModel == null)
            {
                return this.NotFound();
            }

            foreach (var place in viewModel.CardsPlaces)
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

        public IActionResult GetById(int id)
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
                        reservedDays.Add(string.Format("{0:d/M/yyyy}", date));
                    }
                }

                placeViewModel.ReservedDays = JsonConvert.SerializeObject(reservedDays);
            }
            else
            {
                placeViewModel.Rating = 0;
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
    }
}
