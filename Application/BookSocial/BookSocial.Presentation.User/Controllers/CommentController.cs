using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.User.Controllers
{
    public partial class HomeController
    {
        public IActionResult CommentList()
        {
            return View("~/Views/Comment/Login.cshtml");
        }

        public IActionResult CommentInReview(int reviewId)
        {
            return PartialView("~/Views/Review/Partials/CommentInReview.cshtml");
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
