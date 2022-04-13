using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.User.Controllers
{
    public partial class HomeController
    {
        public IActionResult FriendList()
        {
            return View("~/Views/Friend/Index.cshtml");
        }
    }
}
