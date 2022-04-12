using BookSocial.Service.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.Admin.Controllers
{
    public partial class HomeController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IGenreService _genreService;
        private readonly IBookService _bookService;
        private readonly ICommentService _commentService;
        private readonly IAuthorService _authorService;
        private readonly IAuthorBookService _authorBookService;
        private readonly IShelfService _shelfService;
        private readonly IArticleService _articleService;

        public HomeController(
            IUserService userService,
            IGenreService genreService,
            IBookService bookService,
            ICommentService commentService,
            IAuthorService authorService,
            IAuthorBookService authorBookService,
            IShelfService shelfService,
            IArticleService articleService)
        {
            _userService = userService;
            _genreService = genreService;
            _bookService = bookService;
            _commentService = commentService;
            _authorService = authorService;
            _authorBookService = authorBookService;
            _shelfService = shelfService;
            _articleService = articleService;
        }

        public IActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }

        public IActionResult Profile()
        {
            return View("~/Views/Home/Profile.cshtml");
        }

        public IActionResult TestIndex()
        {
            return View("~/Views/test/Index.cshtml");
        }
        
        //public IActionResult Test()
        //{
        //    return View("~/Views/test/Index.cshtml");
        //}
        
        //public IActionResult Test()
        //{
        //    return View("~/Views/test/Index.cshtml");
        //}
    }
}