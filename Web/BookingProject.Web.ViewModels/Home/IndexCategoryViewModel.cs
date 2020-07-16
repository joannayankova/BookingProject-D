namespace BookingProject.Web.ViewModels.Home
{
    using AutoMapper;
    using BookingProject.Data.Models;
    using BookingProject.Services.Mapping;

    public class IndexCategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageName { get; set; }

        public string ImageUrl { get; set; }

        public string Url => $"/b/{this.Name.Replace(' ', '-')}";
    }
}
