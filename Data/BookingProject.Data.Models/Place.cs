﻿namespace BookingProject.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using BookingProject.Data.Common.Models;

    public class Place : BaseDeletableModel<int>
    {
        public Place()
        {
            this.Reviews = new HashSet<Review>();
            this.Images = new HashSet<Image>();
            this.PlaceExtras = new HashSet<PlaceExtra>();
            this.Reservations = new HashSet<Reservation>();
        }

        public new int Id { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string Name { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public int PriceByNight { get; set; }

        public int BedroomsNum { get; set; }

        public int BathroomsNum { get; set; }

        public int BedsNum { get; set; }

        public int MaxGuest { get; set; }

        public bool Pets { get; set; }

        public bool Smoking { get; set; }

        public virtual ICollection<PlaceExtra> PlaceExtras { get; set; }

        [AllowNull]
        public virtual ICollection<Image> Images { get; set; }

        [AllowNull]
        public virtual ICollection<Review> Reviews { get; set; }

        [AllowNull]
        public virtual ICollection<Reservation> Reservations { get; set; }

        public virtual int Rating { get; set; }
    }
}
