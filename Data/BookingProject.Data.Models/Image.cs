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

        public string Name { get; set; }

        public string Ext { get; set; }

        public string Path { get; set; }

        public int PlaceId { get; set; }

        public virtual Place Place { get; set; }
    }
}
