using BookSocial.Presentation.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookSocial.Presentation.Admin.Controllers.HomeController
{
    public partial class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }

        public IActionResult Profile()
        {
            return View("~/Views/Home/Profile.cshtml");
        }

        public IActionResult Logout()
        {
            return View();
        }
    }
}