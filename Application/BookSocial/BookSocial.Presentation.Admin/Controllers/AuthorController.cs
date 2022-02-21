using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.Admin.Controllers
{
    public partial class HomeController
    {
        public IActionResult AuthorList()
        {
            return View("~/Views/AuthorManager/Author/List.cshtml");
        }
    }
}
