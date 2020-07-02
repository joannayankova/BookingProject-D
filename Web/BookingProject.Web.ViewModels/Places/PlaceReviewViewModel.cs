namespace BookingProject.Web.ViewModels.Places
{
    using System;

    using BookingProject.Data.Models;
    using BookingProject.Services.Mapping;
    using Ganss.XSS;

    public class PlaceReviewViewModel : IMapFrom<Review>
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Comment { get; set; }

        public string UserUserName { get; set; }

        public int Rating { get; set; }
    }

}
