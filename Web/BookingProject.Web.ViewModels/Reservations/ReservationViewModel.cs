namespace BookingProject.Web.ViewModels.Reservations
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using BookingProject.Data.Models;
    using BookingProject.Services.Mapping;
    using BookingProject.Web.ViewModels.Places;

    public class ReservationViewModel : IMapFrom<Reservation>, IMapTo<Reservation>
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int PlaceId { get; set; }

        public virtual PlaceViewModel Place { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public double PricePerNight { get; set; }

        public double TotalPrice { get; set; }

        public int NumNights { get; set; }

        public bool Active { get; set; }

        public bool Reviewed { get; set; }
    }
}
