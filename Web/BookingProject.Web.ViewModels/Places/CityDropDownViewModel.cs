namespace BookingProject.Web.ViewModels.Places
{
    using BookingProject.Data.Models;
    using BookingProject.Services.Mapping;

    public class CityDropDownViewModel : IMapFrom<City>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}