using BookingProject.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookingProject.Data.Models
{
    public class PlaceExtra : BaseDeletableModel<int>
    {
        [Required]
        public int PlaceId { get; set; }

        public virtual Place Place { get; set; }

        [Required]
        public int ExtraId { get; set; }

        public virtual Extra Extra { get; set; }
    }
}
