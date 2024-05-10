using Microsoft.AspNetCore.Mvc;
using Post_EDU.Application.ServiceContracts;

namespace Post_EDU.Web.Controllers
{
    public class CategoryController(IPostService postService) : Controller
    {
        private readonly IPostService _postService = postService;

        [HttpGet("Category/{nameCategory?}")]
        public async Task<IActionResult> Index(string nameCategory)
        {
            string? targetCategory;
            if (string.IsNullOrEmpty(nameCategory)) { targetCategory = "Tech"; }
            else { targetCategory = nameCategory; }

            var model = await _postService.GetCategoryPostAsync(targetCategory);
            return View(model);
        }
    }
}
