using BookingProject.Data.Models;
using BookingProject.Services.Mapping;

namespace BookingProject.Web.ViewModels.Places
{
    public class CategoryDropDownViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}