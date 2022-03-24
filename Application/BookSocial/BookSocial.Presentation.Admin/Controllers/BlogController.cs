using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.Admin.Controllers
{
    public partial class HomeController
    {
        public IActionResult BlogList()
        {
            return View("~/Views/UserManager/Blog");
        }
    }
}
