namespace BookingProject.Web.ViewModels.Reservations
{
    using System.Collections.Generic;

    using BookingProject.Data.Models;
    using BookingProject.Services.Mapping;
    using BookingProject.Web.ViewModels.Places;

    public class ListReservationViewModel : IMapFrom<Reservation>, IMapTo<Reservation>
    {
        public PlaceViewModel Place { get; set; }

        public IEnumerable<ReservationViewModel> Reservations { get; set; }
    }
}
