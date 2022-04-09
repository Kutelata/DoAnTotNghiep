using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.User.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Friend()
        {
            return View("~/Views/Friend/Index.cshtml");
        }
    }
}
