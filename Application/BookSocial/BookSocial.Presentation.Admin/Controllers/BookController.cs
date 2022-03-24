using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.Admin.Controllers
{
    public partial class HomeController
    {
        public IActionResult BookList(int size, int page)
        {

            return View("~/View/Book/List");
        }

        public IActionResult DetailBook()
        {
            return View("~/View/Book/Detail");
        }

        public IActionResult CreateBook()
        {
            return View("~/View/Book/Create");
        }
        
        public IActionResult EditBook()
        {
            return View("~/View/Book/Edit");
        }
    }
}
