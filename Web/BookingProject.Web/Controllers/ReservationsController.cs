namespace BookingProject.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

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

        public ReservationsController(IReservationsService reservationsService, IPlacesService placesService, UserManager<ApplicationUser> userManager)
        {
            this.placesService = placesService;
            this.reservationsService = reservationsService;
            this.userManager = userManager;
        }

        [HttpGet]
        [Authorize]

        public async Task<IActionResult> DetailReservation(string dates, int placeId)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            if (!this.ModelState.IsValid)
            {
                return this.View(dates);
            }

            var place = this.placesService.GetById<PlaceViewModel>(placeId);
            string[] splitDates = dates.Split(" - ");
            DateTime startDate = DateTime.Parse(splitDates[0]);
            DateTime endDate = DateTime.Parse(splitDates[1]);
            int numNights = (int)(endDate - startDate).TotalDays;
            double totalPrice = Math.Round(double.Parse(place.PriceByNight) * numNights);

            var viewModel = new CreateReservationInputModel
            {
                PlaceId = placeId,
                Dates = dates,
                Place = place,
                StartDate = startDate,
                EndDate = endDate,
                TotalPrice = totalPrice,
                NumNights = numNights,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationInputModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var reservationId = await this.reservationsService.CreateReservationAsync(
                input.PlaceId,
                user.Id,
                input.Dates,
                input.PriceByNight,
                input.TotalPrice,
                input.NumNights);
            this.TempData["InfoMessage"] = "Reservation created!";

            return this.RedirectToAction(nameof(this.UserReservations));
        }

        public async Task<IActionResult> UserReservations()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var viewModel = new ListReservationViewModel
            {
                Reservations =
                   this.reservationsService.GetAllByUser<ReservationViewModel>(user.Id).ToList(),
            };
            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }

        public async Task<IActionResult> PlaceReservations(int id)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var place = this.placesService.GetById<PlaceViewModel>(id);

            if (place == null || place.User.Id != user.Id)
            {
                return this.NotFound();
            }

            var viewModel = new ListReservationViewModel
            {
                Place = place,
                Reservations =
                   this.reservationsService.GetAllByPlace<ReservationViewModel>(id).ToList(),
            };
            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }
    }
}
