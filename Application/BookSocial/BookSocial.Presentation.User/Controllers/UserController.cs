using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.User.Controllers
{
    public partial class HomeController
    {
        public IActionResult UserDetail()
        {
            return View("~/Views/User/Index.cshtml");
        }


    }
}
