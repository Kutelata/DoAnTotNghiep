using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.Admin.Controllers
{
    public partial class HomeController
    {
        public IActionResult AuthorizeList()
        {
            return View("~/Views/Home/Index.cshtml");
        }

        public IActionResult LockAccount()
        {
            return View();
        }

        public IActionResult CreateAccount()
        {
            return View();
        }

        public IActionResult EditAccount()
        {
            return View();
        }

        public IActionResult DeleteAccount()
        {
            return View();
        }

        
    }
}
