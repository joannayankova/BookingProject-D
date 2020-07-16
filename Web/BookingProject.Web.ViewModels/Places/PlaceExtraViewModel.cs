namespace BookingProject.Web.ViewModels.Places
{
    using AutoMapper;
    using BookingProject.Data.Models;
    using BookingProject.Services.Mapping;

    public class PlaceExtraViewModel : IMapFrom<PlaceExtra>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsSelected { get; set; }
    }
}
