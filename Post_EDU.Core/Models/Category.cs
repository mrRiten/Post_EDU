using System.ComponentModel.DataAnnotations;

namespace Post_EDU.Core.Models
{
    public class Category
    {
        [Key]
        public int IdCategory { get; set; }
        public string NameCategory { get; set; }
        public string Description { get; set; }

        public string PathDefaultImg { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
