using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.Admin.Controllers
{
    public partial class HomeController
    {
        public IActionResult InboxList()
        {
            return View("~/Views/Inbox/Index.cshtml");
        }
    }
}
