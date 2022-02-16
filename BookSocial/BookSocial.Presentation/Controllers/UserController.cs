using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
