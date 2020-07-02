namespace BookingProject.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using BookingProject.Data.Common.Models;

    public class Reservation : BaseDeletableModel<int>
    {
        public new int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int PlaceId { get; set; }

        public virtual Place Place { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int PricePerNight { get; set; }

        public int TotalPrice { get; set; }

        public int NumNights { get; set; }

        public bool Active { get; set; }

        public bool Reviewed { get; set; }
    }
}
