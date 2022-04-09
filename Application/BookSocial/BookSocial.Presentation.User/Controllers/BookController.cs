using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.User.Controllers
{
    public class BookController : Controller
    {
        public IActionResult BookShelf()
        {
            return View();
        }

        public IActionResult BookSearch()
        {
            return View();
        }

        public IActionResult BookDetail()
        {
            return View();
        }
    }
}
