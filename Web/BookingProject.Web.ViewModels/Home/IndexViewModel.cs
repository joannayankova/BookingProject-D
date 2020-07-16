namespace BookingProject.Web.ViewModels.Home
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using BookingProject.Web.ViewModels.Places;
    using BookingProject.Web.ViewModels.Reservations;

    public class IndexViewModel
    {
        public IEnumerable<IndexCategoryViewModel> Categories { get; set; }

        public IEnumerable<CityDropDownViewModel> Cities { get; set; }

        public IEnumerable<GuestNumberDropDownViewModel> GuestNumbers { get; set; }

        public int CityId { get; set; }

        public int GuestNumber { get; set; }

        public string Dates { get; set; }
    }
}
