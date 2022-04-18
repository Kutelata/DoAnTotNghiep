using AutoMapper;
using BookSocial.EntityClass.DTO;
using BookSocial.Service.ServiceInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.Admin.Controllers
{
    [Authorize(Policy = "All")]
    public partial class HomeController : BaseController
    {
        private readonly IMapper _mapper;

        private readonly IUserService _userService;
        private readonly IGenreService _genreService;
        private readonly IBookService _bookService;
        private readonly ICommentService _commentService;
        private readonly IAuthorService _authorService;
        private readonly IAuthorBookService _authorBookService;
        private readonly IShelfService _shelfService;
        private readonly IArticleService _articleService;

        public HomeController(
            IMapper mapper,

            IUserService userService,
            IGenreService genreService,
            IBookService bookService,
            ICommentService commentService,
            IAuthorService authorService,
            IAuthorBookService authorBookService,
            IShelfService shelfService,
            IArticleService articleService)
        {
            _mapper = mapper;

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

        public IActionResult ChangePassword()
        {
            return View("~/Views/Home/ChangePassword.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePassword changePassword)
        {
            var userIdClaim = User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
            var user = await _userService.GetById(Convert.ToInt32(userIdClaim));
            if (user.Password != changePassword.OldPassword)
            {
                ModelState.AddModelError("OldPassword", "Old Password is wrong");
            }
            if (ModelState.IsValid)
            {
                user.Password = changePassword.NewPassword;
                int result = await _userService.Update(user);
                if (result != 0)
                {
                    TempData["Success"] = "Update Password success!";
                }
                else
                {
                    TempData["Fail"] = "Update Password failed!";
                }
                return RedirectToAction("Index", "Home");
            }
            return View("~/Views/Home/ChangePassword.cshtml");
        }
    }
}