using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.User.Controllers
{
    public partial class HomeController
    {
        public IActionResult AuthorDetail(int authorId)
        {
            return View("~/Views/Author/Index.cshtml");
        }
    }
}
