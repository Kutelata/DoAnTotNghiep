using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.Admin.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Login.cshtml");
        }
    }
}
