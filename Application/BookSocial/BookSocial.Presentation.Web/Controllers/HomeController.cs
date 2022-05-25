using AutoMapper;
using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Enum;
using BookSocial.Service.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.Web.Controllers
{
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
        private readonly IReviewService _reviewService;
        private readonly IFriendService _friendService;

        public HomeController(
            IMapper mapper,

            IUserService userService,
            IGenreService genreService,
            IBookService bookService,
            ICommentService commentService,
            IAuthorService authorService,
            IAuthorBookService authorBookService,
            IShelfService shelfService,
            IReviewService reviewService,
            IFriendService friendService)
        {
            _mapper = mapper;

            _userService = userService;
            _genreService = genreService;
            _bookService = bookService;
            _commentService = commentService;
            _authorService = authorService;
            _authorBookService = authorBookService;
            _shelfService = shelfService;
            _reviewService = reviewService;
            _friendService = friendService;
        }

        public async Task<IActionResult> Index()
        {
            var userIdClaim = User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
            var reviewLists = await _reviewService.GetReviewList();
            var shelfLists = await _shelfService.GetShelfListHomes(Convert.ToInt32(userIdClaim));
            var commentLists = await _commentService.GetRecentActivityComment();
            var dataInPage = new HomeList();
            int page = 1;
            int size = 2;

            dataInPage.ReviewList = reviewLists.ToList();
            if (reviewLists != null)
            {
                foreach (var data in dataInPage.ReviewList)
                {
                    data.AuthorListByBookId = await _authorService.GetAuthorListByBookId(data.BookId);
                    var checkBookInShelf = await _shelfService.GetByBookAndUserId(data.BookId, Convert.ToInt32(userIdClaim));
                    if (checkBookInShelf != null)
                    {
                        data.UserClaimProgressRead = (ProgressReadOrigin)checkBookInShelf.ProgressRead;
                    }
                    else { data.UserClaimProgressRead = ProgressReadOrigin.NotRead; }
                }

                dataInPage.ShelfListHome = shelfLists.ToList();
                foreach (var data in dataInPage.ShelfListHome)
                {
                    data.AuthorListByBookId = await _authorService.GetAuthorListByBookId(data.BookId);
                }
                dataInPage.RecentActivityComment = commentLists.ToList();
                dataInPage.ReviewList = dataInPage.ReviewList.Skip((page - 1) * size).Take(size).ToList();
            }
            return View("~/Views/Home/Index.cshtml", dataInPage);
        }
    }
}