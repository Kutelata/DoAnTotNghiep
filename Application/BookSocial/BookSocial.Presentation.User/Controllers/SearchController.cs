using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.User.Controllers
{
    public partial class HomeController
    {
        public IActionResult SearchList()
        {
            return View("~/Views/Search/Index.cshtml");
        }
    }
}
