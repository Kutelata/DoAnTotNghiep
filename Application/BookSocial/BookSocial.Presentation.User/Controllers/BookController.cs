using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.User.Controllers
{
    public partial class HomeController
    {
        public async Task<IActionResult> BookShelf(int userId)
        {
            var userShelf = await _shelfService.GetByUserId(userId);

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
