using System.ComponentModel.DataAnnotations;

namespace Post_EDU.Core.Models
{
    public class Comment
    {
        [Key]
        public int IdComment { get; set; }
        public string TextComment { get; set; }
        public DateTime DateOfComment { get; set; }

        public int UserId { get; set; }
        public User Author { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
