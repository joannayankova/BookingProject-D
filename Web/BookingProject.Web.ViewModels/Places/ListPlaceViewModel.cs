namespace BookingProject.Web.ViewModels.Places
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using BookingProject.Data.Models;
    using BookingProject.Services.Mapping;

    public class ListPlaceViewModel : IMapFrom<Place>
    {
        public int Rating { get; set; }

        public string ReviewsCount { get; set; }

        public List<PlaceReviewViewModel> Reviews { get; set; }

        public IEnumerable<PlaceViewModel> Places { get; set; }

        public IEnumerable<CardPlaceViewModel> CardsPlaces { get; set; }
    }
}
