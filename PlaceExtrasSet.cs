namespace BookingProject.Data.Models
{
    using System.Collections.Generic;

    using BookingProject.Data.Common.Models;

    public class PlaceExtrasSet : BaseDeletableModel<int>
    {
        public PlaceExtrasSet()
        {
            this.Extras = new HashSet<Extra>();
        }

        public new int Id { get; set; }

        public int PlaceForeignKey { get; set; }

        public virtual Place Place { get; set; }

        public virtual ICollection<Extra> Extras { get; set; }
    }
}
