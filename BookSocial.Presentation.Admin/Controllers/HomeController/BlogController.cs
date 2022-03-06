using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.Admin.Controllers.HomeController
{
    public partial class HomeController
    {
        public IActionResult BlogList()
        {
            return View("~/Views/UserManager/Blog");
        }
    }
}
