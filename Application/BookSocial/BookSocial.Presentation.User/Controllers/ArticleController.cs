using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.User.Controllers
{
    public partial class HomeController
    {
        public IActionResult ArticleList()
        {
            return View("~/Views/Login.cshtml");
        }

        public IActionResult CreateArticle()
        {
            return View("~/Views/Login.cshtml");
        }

        public IActionResult EditArticle()
        {
            return View("~/Views/Login.cshtml");
        }

        public IActionResult DeleteArticle()
        {
            return View("~/Views/Login.cshtml");
        }
    }
}
