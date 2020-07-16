namespace BookingProject.Web.ViewModels.Places

{
    using BookingProject.Web.ViewModels.Reservations;

    public class PlaceReservationViewModel
    {
        public PlaceViewModel PlaceViewModel { get; set; }

        public CreateReservationInputModel CreateReservationInputModel { get; set; }
    }
}
