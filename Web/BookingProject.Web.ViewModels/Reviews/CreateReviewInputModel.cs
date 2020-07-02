namespace BookingProject.Web.ViewModels.Reviews
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CreateReviewInputModel
    {
        public int PlaceId { get; set; }

        public string UserId { get; set; }

        public string Comment { get; set; }

        public int Rating { get; set; } = 5;
    }
}
