using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.Admin.Controllers.HomeController
{
    public partial class HomeController
    {
        public IActionResult BookList(int size, int page)
        {

            return View("~/View/LibraryManager/Book/List");
        }

        public IActionResult DetailBook()
        {
            return View("~/View/LibraryManager/Book/Detail");
        }

        public IActionResult CreateBook()
        {
            return View("~/View/LibraryManager/Book/Create");
        }
        
        public IActionResult EditBook()
        {
            return View("~/View/LibraryManager/Book/Edit");
        }
    }
}
