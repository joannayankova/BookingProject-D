namespace BookingProject.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using BookingProject.Data.Common.Models;
    using ForumSystem.Data.Models;

    public class Vote : BaseModel<int>
    {
        public int ReviewId { get; set; }

        public virtual Review Review { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public VoteType Type { get; set; }
    }
}
