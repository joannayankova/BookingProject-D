namespace BookingProject.Web.ViewModels.Places
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using BookingProject.Data.Models;
    using BookingProject.Services.Mapping;
    using BookingProject.Web.ViewModels.Home;
    using BookingProject.Web.ViewModels.Reservations;

    public class ListPlaceViewModel : IMapFrom<Place>
    {
        public int Id { get; set; }

        //public int Rating { get; set; }

        //public string ReviewsCount { get; set; }

        public int CurrentPage { get; set; }

        public int PagesCount { get; set; }

        public List<PlaceReviewViewModel> Reviews { get; set; }

        public IEnumerable<PlaceViewModel> Places { get; set; }

        public IEnumerable<IndexCategoryViewModel> Categories { get; set; }

        public IEnumerable<CityDropDownViewModel> Cities { get; set; }

        public IEnumerable<GuestNumberDropDownViewModel> GuestNumbers { get; set; }

        public IEnumerable<CardPlaceViewModel> CardPlaces { get; set; }

        public int CityId { get; set; }

        public int GuestNumber { get; set; }

        public string Dates { get; set; }

        public string SortBy { get; set; }
    }
}
