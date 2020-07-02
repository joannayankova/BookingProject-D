﻿namespace BookingProject.Data.Models
{
    using BookingProject.Data.Common.Models;
    using System.Collections.Generic;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Places = new HashSet<Place>();
        }

        public new int Id { get; set; }

        public string Name { get; set; }

        public string ImageName { get; set; }

        public string ImageUrl { get; set; }

        public virtual ICollection<Place> Places { get; set; }
    }
}
