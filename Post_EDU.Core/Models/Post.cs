using System.ComponentModel.DataAnnotations;

namespace Post_EDU.Core.Models
{
    public class Post
    {
        [Key]
        public int IdPost { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public string Slug { get; set; }

        public int LikeCount { get; set; }

        public DateTime DateOfCreate { get; set; }
        public DateTime DateOfEdit { get; set; }

        public int AuthorId { get; set; }
        public User Author { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public string? PathImg { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Like> Likes { get; set; }
    }
}
