using Microsoft.AspNetCore.Mvc;

namespace BookSocial.API.Controllers
{
    public class FriendController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
