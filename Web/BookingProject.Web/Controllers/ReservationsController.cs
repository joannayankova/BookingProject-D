namespace BookingProject.Web.Controllers
{
    using System.Threading.Tasks;

    using AutoMapper;
    using BookingProject.Data.Models;
    using BookingProject.Services.Data;
    using BookingProject.Services.Data.IServices;
    using BookingProject.Web.ViewModels.Places;
    using BookingProject.Web.ViewModels.Reservations;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ReservationsController : BaseController
    {
        private readonly IPlacesService placesService;
        private readonly IReservationsService reservationsService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;

        public ReservationsController(IReservationsService reservationsService, IPlacesService placesService, UserManager<ApplicationUser> userManager)
        {
            this.placesService = placesService;
            this.reservationsService = reservationsService;
            this.userManager = userManager;
        }

        public IActionResult CreateReservation()
        {
            var viewModel = new CreateReservationViewModel();
            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]

        public async Task<IActionResult> DetailReservation(string dates, int placeId)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            if (!this.ModelState.IsValid)
            {
                return this.View(dates);
            }

            var place = this.placesService.GetById<PlaceViewModel>(placeId);

            var viewModel = new DetailReservationViewModel
            {
                PlaceId = placeId,
                Dates = dates,
                Place = place,
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> CreateReservation(CreateReservationViewModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }
            var reservationId = await this.reservationsService.CreateReservationAsync(
                input.PlaceId,
                user.Id,
                input.Dates);
            this.TempData["InfoMessage"] = "Reservation created!";

            return this.RedirectToAction(nameof(this.CreateReservation), new { id = reservationId });

        }
    }
}
