using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.Admin.Controllers.HomeController
{
    public partial class HomeController
    {
        public IActionResult AuthorList()
        {
            return View("~/Views/LibraryManager/Author/Index.cshtml");
        }

        public IActionResult DetailAuthor()
        {
            return View("~/View/LibraryManager/Author/Detail");
        }

        public IActionResult CreateAuthor()
        {
            return View("~/Views/LibraryManager/Author/Create.cshtml");
        }

        public IActionResult EditAuthor()
        {
            return View("~/Views/LibraryManager/Author/Edit.cshtml");
        }
    }
}
