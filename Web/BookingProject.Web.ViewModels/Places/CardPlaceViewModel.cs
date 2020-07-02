namespace BookingProject.Web.ViewModels.Places
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using BookingProject.Data.Models;
    using BookingProject.Services.Mapping;

    public class CardPlaceViewModel : IMapFrom<Place>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CategoryName { get; set; }

        public string CityName { get; set; }

        public int MaxGuest { get; set; }

        public int BathroomsNum { get; set; }

        public int PriceByNight { get; set; }

        public int BedsNum { get; set; }

        public int Rating { get; set; }

        public string ReviewsCount { get; set; }

        public List<PlaceReviewViewModel> Reviews { get; set; }
    }
}
