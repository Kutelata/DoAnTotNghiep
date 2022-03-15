using BookSocial.Presentation.Admin.Models;
using BookSocial.Service.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookSocial.Presentation.Admin.Controllers.HomeController
{
    public partial class HomeController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IGenreService _genreService;

        public HomeController(
            IUserService userService,
            IGenreService genreService)
        {
            _userService = userService;
            _genreService = genreService;
        }

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