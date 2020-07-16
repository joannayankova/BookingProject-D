namespace BookingProject.Data.Models
{
    using BookingProject.Data.Common.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Extra : BaseDeletableModel<int>
    {
        public new int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        public List<PlaceExtra> PlaceExtras { get; set; }
    }
}
