using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.Admin.Controllers
{
    public class InboxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
