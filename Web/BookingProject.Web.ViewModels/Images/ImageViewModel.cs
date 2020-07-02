namespace BookingProject.Web.ViewModels.Image
{
    using System.Collections.Generic;
    using System.Text;

    using BookingProject.Data.Models;
    using BookingProject.Services.Mapping;

    public class ImageViewModel : IMapFrom<Image>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public string Ext { get; set; }
    }
}
