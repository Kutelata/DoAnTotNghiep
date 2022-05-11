using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.User.Controllers
{
    public partial class HomeController
    {
        public IActionResult CommentList()
        {
            return View("~/Views/Comment/Login.cshtml");
        }

        public IActionResult CommentInReview()
        {
            return PartialView("~/Views/Comment/Login.cshtml");
        }

        public IActionResult CreateComment()
        {
            return View("~/Views/Login.cshtml");
        }

        public IActionResult EditComment()
        {
            return View("~/Views/Login.cshtml");
        }

        public IActionResult DeleteComment()
        {
            return View("~/Views/Login.cshtml");
        }
    }
}
