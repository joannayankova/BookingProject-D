namespace BookingProject.Data.Models
{
    using BookingProject.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;

    public class City : BaseDeletableModel<int>
    {
        public new int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        public int RegionId { get; set; }

        public virtual Region Region { get; set; }
    }
}
