namespace BookingProject.Web.ViewModels.Places
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Net;
    using System.Text.RegularExpressions;

    using BookingProject.Data.Models;
    using BookingProject.Services.Mapping;

    public class PlaceViewModel : IMapFrom<Place>, IMapTo<Place>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CategoryName { get; set; }

        public ApplicationUser User { get; set; }

        public virtual City City { get; set; }

        public int CityId { get; set; }

        public string CityName { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public string PriceByNight { get; set; }

        public int BedroomsNum { get; set; }

        public int BathroomsNum { get; set; }

        public int BedsNum { get; set; }

        public int MaxGuest { get; set; }

        public bool Pets { get; set; }

        public bool Smoking { get; set; }

        public string ReviewsCount { get; set; }

        public List<PlaceExtra> PlaceExtras { get; set; }

        public List<Image> Images { get; set; }

        public List<Reservation> Reservations { get; set; }

        // Reservation data
        public int PlaceId { get; set; }

        [Required]
        public string Dates { get; set; }

        // Review data
        public virtual int Rating { get; set; }

        public List<PlaceReviewViewModel> Reviews { get; set; }

        public string ReservedDays { get; set; }
    }
}
