using BookSocial.Service.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.Admin.Controllers
{
    public partial class HomeController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IGenreService _genreService;
        private readonly IBookService _bookService;

        public HomeController(
            IUserService userService,
            IGenreService genreService,
            IBookService bookService)
        {
            _userService = userService;
            _genreService = genreService;
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }

        public IActionResult Profile()
        {
            return View("~/Views/Home/Profile.cshtml");
        }
    }
}