using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Post_EDU.Core.UploadModels
{
    public class UserUpload
    {
        [Required(ErrorMessage = "Please enter a Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a Password")]
        public string Password { get; set; }
        public IFormFile? PathImg { get; set; }
    }
}
