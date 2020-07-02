namespace BookingProject.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using BookingProject.Data.Common.Models;

    public class Review : BaseDeletableModel<int>
    {
        public new int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int PlaceId { get; set; }

        public virtual Place Place { get; set; }

        public int? Rating { get; set; }

        public string Comment { get; set; }
    }
}
