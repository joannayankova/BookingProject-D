namespace BookingProject.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using BookingProject.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Places = new HashSet<Place>();
        }

        public new int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        public string ImageName { get; set; }

        public string ImageUrl { get; set; }

        public virtual ICollection<Place> Places { get; set; }
    }
}
