using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Post_EDU.Application.ServiceContracts;

namespace Post_EDU.Web.Controllers
{
    public class UserController(IUserService userService) : Controller
    {
        private readonly IUserService _userService = userService;

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userName = HttpContext.User.Identity.Name;
            var user = await _userService.GetAllInfoAsync(userName);
            if (user != null)
            {
                return View(user);
            }

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpGet("User/Details/{userId}")]
        public async Task<IActionResult> Details(int userId)
        {
            var user = await _userService.GetAsync(userId);
            if (user != null)
            {
                return View(user);
            }

            return RedirectToAction("Index", "Home");
        }

    }
}
