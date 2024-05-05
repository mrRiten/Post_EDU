using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Post_EDU.Application.ServiceContracts;
using Post_EDU.Core.UploadModels;
using Post_EDU.Web.WebHostHelpers;

namespace Post_EDU.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICommentService _commentService;
        private readonly IWebHostEnvironment _webHost;

        public PostController(IPostService postService, ICommentService commentService, IWebHostEnvironment webHost)
        {
            _postService = postService;
            _commentService = commentService;
            _webHost = webHost;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await _postService.GetAllAsync();
            return View(posts);
        }

        [Authorize]
        [HttpGet("Post/Details/{slug}")]
        public async Task<IActionResult> Details(string slug)
        {
            var post = await _postService.GetAsync(slug);

            return View(post);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(PostUpload model)
        {
            if (ModelState.IsValid)
            {
                string? fileName = null;

                if (model.PathImg != null && model.PathImg.Length > 0)
                {
                    var uploadHelper = new UploadFileHelper(_webHost);
                    fileName = uploadHelper.Active(model.PathImg);
                }

                await _postService.CreateAsync(model, HttpContext.User.Identity.Name, fileName);
                return RedirectToAction("Index", "Post");
            }

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddComment(CommentUpload model)
        {
            var userName = HttpContext.User.Identity.Name;

            if (userName == null) { return RedirectToAction("Index", "Post"); }

            if (ModelState.IsValid)
            {
                await _commentService.CreateAsync(model, userName);

                return RedirectToAction("Details", "Post", new { slug = model.CurrentPostSlug });
            }

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddLike(LikeUpload model)
        {
            var userName = HttpContext.User.Identity.Name;

            await _postService.AddLikeAsync(model, userName);
            return RedirectToAction("Details", "Post", new { slug = model.CurrentPostSlug });
        }

    }
}
