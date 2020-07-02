namespace BookingProject.Web.ViewModels.Places
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using BookingProject.Data.Models;
    using BookingProject.Services.Mapping;

    public class RegionDropDownViewModel : IMapFrom<Region>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
