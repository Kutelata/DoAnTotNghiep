using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.Admin.Controllers
{
    public partial class HomeController
    {
        public IActionResult UserList()
        {
            return View("~/Views/User/Index");
        }
    }
}
