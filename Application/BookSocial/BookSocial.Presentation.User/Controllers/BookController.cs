using BookSocial.EntityClass.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.User.Controllers
{
    public partial class HomeController
    {
        public IActionResult BookDetail(int bookId)
        {
            return View("~/Views/Book/Index.cshtml");
        }
    }
}