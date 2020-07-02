namespace BookingProject.Web.ViewModels.Reservations
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using BookingProject.Data.Models;
    using BookingProject.Services.Mapping;
    using BookingProject.Web.ViewModels.Places;

    public class DetailReservationViewModel : IMapFrom<Reservation>, IMapTo<Reservation>
    {
        public int PlaceId { get; set; }

        [Required]
        public string Dates { get; set; }

        public PlaceViewModel Place { get; set; }
    }
}
