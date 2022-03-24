using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.Admin.Controllers
{
    public partial class HomeController
    {
        public IActionResult AuthorList()
        {
            return View("~/Views/Author/Index.cshtml");
        }

        public IActionResult DetailAuthor()
        {
            return View("~/View/Author/Detail");
        }

        public IActionResult CreateAuthor()
        {
            return View("~/Views/Author/Create.cshtml");
        }

        public IActionResult EditAuthor()
        {
            return View("~/Views/Author/Edit.cshtml");
        }
    }
}
