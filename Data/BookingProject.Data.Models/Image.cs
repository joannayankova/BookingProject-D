namespace BookingProject.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    using BookingProject.Data.Common.Models;

    public class Image : BaseDeletableModel<int>
    {
        public new int Id { get; set;  }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [StringLength(50)]
        [Required]
        public string Ext { get; set; }

        [StringLength(50)]
        [Required]
        public string Path { get; set; }

        [Required]
        public int PlaceId { get; set; }

        public virtual Place Place { get; set; }
    }
}
