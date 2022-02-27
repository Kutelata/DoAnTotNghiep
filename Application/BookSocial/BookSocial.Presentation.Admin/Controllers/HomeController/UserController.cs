using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.Admin.Controllers.HomeController
{
    public partial class HomeController
    {
        public IActionResult UserList()
        {
            return View("~/Views/UserManager/User/Index");
        }
    }
}
