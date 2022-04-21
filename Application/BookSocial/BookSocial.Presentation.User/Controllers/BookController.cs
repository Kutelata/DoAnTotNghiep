using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.User.Controllers
{
    public partial class HomeController
    {
        public IActionResult BookShelf()
        {
            return View("~/Views/Shelf/Index.cshtml");
        }

        public IActionResult BookDetail()
        {
            return View("~/Views/Book/Index.cshtml");
        }

        //public IActionResult BookDetail()
        //{
        //    return View();
        //}
    }
}
