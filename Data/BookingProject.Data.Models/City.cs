namespace BookingProject.Data.Models
{
    using BookingProject.Data.Common.Models;

    public class City : BaseDeletableModel<int>
    {
        public new int Id { get; set; }

        public string Name { get; set; }

        public int RegionId { get; set; }

        public virtual Region Region { get; set; }
    }
}
