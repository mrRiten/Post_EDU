using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Post_EDU.Application.ServiceContracts;
using Post_EDU.Core.UploadModels;
using Post_EDU.Web.WebHostHelpers;

namespace Post_EDU.Web.Controllers
{
    public class AuthorizeController : Controller
    {
        private readonly IAuthorizeService _authorizeService;
        private readonly IWebHostEnvironment _webHost;

        public AuthorizeController(IAuthorizeService authorizeService, IWebHostEnvironment webHost)
        {
            _authorizeService = authorizeService;
            _webHost = webHost;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserUpload model)
        {
            if (ModelState.IsValid)
            {
                var claimsPrincipal = await _authorizeService.SingInAsync(model);
                var authenticationProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(5)
                };
                await HttpContext.SignInAsync(claimsPrincipal, authenticationProperties);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserUpload model)
        {
            if (ModelState.IsValid)
            {
                string fileName = null;

                if (model.PathImg != null)
                {
                    var uploadHelper = new UploadFileHelper(_webHost);
                    fileName = uploadHelper.Active(model.PathImg);
                }

                await _authorizeService.RegisterAsync(model, fileName);
                return RedirectToAction("Index", "Home");

            }
            return View(model);
        }

    }
}
