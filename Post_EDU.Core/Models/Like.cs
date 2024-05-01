using System.ComponentModel.DataAnnotations;

namespace Post_EDU.Core.Models
{
    public class Like
    {
        [Key]
        public int IdLike { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
