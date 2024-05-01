using System.ComponentModel.DataAnnotations;

namespace Post_EDU.Core.UploadModels
{
    public class CommentUpload
    {
        public int PostId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "You must write a text before to comment")]
        public string TextComment { get; set; }
        public string CurrentPostSlug { get; set; }
    }
}
