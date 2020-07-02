using BookingProject.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingProject.Data.Models
{
    public class PlaceExtra : BaseDeletableModel<int>
    {
        public int PlaceId { get; set; }

        public virtual Place Place { get; set; }

        public int ExtraId { get; set; }

        public virtual Extra Extra { get; set; }
    }
}
