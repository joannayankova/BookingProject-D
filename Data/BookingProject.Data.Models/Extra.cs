namespace BookingProject.Data.Models
{
    using BookingProject.Data.Common.Models;
    using System.Collections.Generic;

    public class Extra : BaseDeletableModel<int>
    {
        public new int Id { get; set; }

        public string Name { get; set; }

        public bool IsSelected { get; set; }

        public List<PlaceExtra> PlaceExtras { get; set; }
    }
}
