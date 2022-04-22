using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.User.Controllers
{
    public partial class HomeController
    {
        public IActionResult ReviewList()
        {
            return View("~/Views/Login.cshtml");
        }

        public IActionResult CreateReview()
        {
            return View("~/Views/Login.cshtml");
        }

        public IActionResult EditReview()
        {
            return View("~/Views/Login.cshtml");
        }

        public IActionResult DeleteReview()
        {
            return View("~/Views/Login.cshtml");
        }
    }
}
