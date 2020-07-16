namespace BookingProject.Data.Models
{
    using BookingProject.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;

    public class Region : BaseDeletableModel<int>
    {
        public new int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
