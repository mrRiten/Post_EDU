namespace Post_EDU.Core.Models
{
    public class CategoryPost
    {
        public ICollection<Category> Categories { get; set; }
        public ICollection<Post> Posts { get; set;}
        public Category CurrentCategory { get; set; }
    }
}
