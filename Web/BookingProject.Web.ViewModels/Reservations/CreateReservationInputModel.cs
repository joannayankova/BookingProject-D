namespace BookingProject.Web.ViewModels.Reservations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using BookingProject.Data.Models;
    using BookingProject.Services.Mapping;
    using BookingProject.Web.ViewModels.Places;

    public class CreateReservationInputModel : IMapFrom<Reservation>, IMapTo<Reservation>
    {
        public int PlaceId { get; set; }

        [Required]
        public string Dates { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public double PriceByNight { get; set; }

        public double TotalPrice { get; set; }

        public int NumNights { get; set; }

        public PlaceViewModel Place { get; set; }
    }
}
