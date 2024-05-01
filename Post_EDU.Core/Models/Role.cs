using System.ComponentModel.DataAnnotations;

namespace Post_EDU.Core.Models
{
    public class Role
    {
        [Key]
        public int IdRole { get; set; }
        public string RoleName { get; set; }

        public string PathDefaultImg { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
