using System.ComponentModel.DataAnnotations;

namespace Post_EDU.Core.Models
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Password { get; set; }

        public DateTime DateOfRegister { get; set; }
        public DateTime LastLogin { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public string? PathImg { get; set; }

        public ICollection<Post> Posts { get; set; }

        public ICollection<Like> Likes { get; set; }
    }
}
