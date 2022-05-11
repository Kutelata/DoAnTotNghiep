using BookSocial.EntityClass.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.User.Controllers
{
    public partial class HomeController
    {
        public async Task<IActionResult> BookProfile(int bookId)
        {

            return View("~/Views/Book/Index.cshtml");
        }
    }
}