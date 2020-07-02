namespace BookingProject.Data.Models
{
    using BookingProject.Data.Common.Models;

    public class Region : BaseDeletableModel<int>
    {
        public new int Id { get; set; }

        public string Name { get; set; }
    }
}
