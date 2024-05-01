using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Post_EDU.Core.UploadModels
{
    public class PostUpload
    {
        [Required(ErrorMessage = "Please enter a title")]
        [StringLength(64, MinimumLength = 4, ErrorMessage = "Title must be between 5 and 100 characters")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter a description")]
        [StringLength(124, ErrorMessage = "Description cannot be longer than 124 characters")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter the text")]
        public string Text { get; set; }
        [Required(ErrorMessage = "Please choose the Category")]
        public int CategoryId { get; set; }

        public IFormFile? PathImg { get; set; }
    }
}
