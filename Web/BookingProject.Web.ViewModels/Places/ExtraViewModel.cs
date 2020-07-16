namespace BookingProject.Web.ViewModels.Places
{
    using BookingProject.Data.Models;
    using BookingProject.Services.Mapping;

    public class ExtraViewModel : IMapFrom<Extra>, IMapTo<Extra>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsSelected { get; set; } = false;
    }
}
