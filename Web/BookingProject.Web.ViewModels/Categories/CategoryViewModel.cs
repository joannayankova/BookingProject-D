namespace BookingProject.Web.ViewModels.Categories
{
    using BookingProject.Data.Models;
    using BookingProject.Services.Mapping;
    using BookingProject.Web.ViewModels.Places;
    using System.Collections.Generic;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageName { get; set; }

        public string ImageUrl { get; set; }

        public int CurrentPage { get; set; }

        public int PagesCount { get; set; }

        // public IEnumerable<PlaceViewModel> Places { get; set; }

        public IEnumerable<CardPlaceViewModel> CardPlaces { get; set; }
    }
}
