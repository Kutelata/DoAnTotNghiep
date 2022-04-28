using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Enum;
using BookSocial.Service.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.User.Controllers
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
        private readonly IReviewService _reviewService;
        private readonly IFriendService _friendService;

        public HomeController(
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

        public async Task<IActionResult> Index(string filter = "Global")
        {
            var userIdClaim = User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
            var allData = await _reviewService.GetReviewList();
            var dataInPage = allData;
            List<ReviewList> reviewLists = new();
            int page = 1;
            int size = 2;

            if (allData != null)
            {
                if (Request.Query.ContainsKey("filter"))
                {
                    var newFilter = Request.Query["filter"].ToString();
                    filter = newFilter;
                }
                if (filter != null)
                {
                    switch (filter)
                    {
                        case "Global":
                            dataInPage = allData; break;
                        case "Friend":
                            foreach (var data in allData)
                            {
                                var checkUserFriend =
                                    await _friendService.GetByUserAndUserFriendId(Convert.ToInt32(userIdClaim), data.UserId);
                                var checkUserFriendReverse =
                                    await _friendService.GetByUserAndUserFriendId(data.UserId, Convert.ToInt32(userIdClaim));
                                if (checkUserFriend != null || checkUserFriendReverse != null)
                                {
                                    reviewLists.Add(data);
                                }
                            };
                            dataInPage = reviewLists;
                            break;
                    }
                }

                foreach (var data in dataInPage)
                {
                    var checkBookInShelf = await _shelfService.GetByBookAndUserId(data.BookId, Convert.ToInt32(userIdClaim));
                    if (checkBookInShelf != null)
                    {
                        data.UserClaimProgressRead = (ProgressReadOrigin)checkBookInShelf.ProgressRead;
                    }
                    else { data.UserClaimProgressRead = ProgressReadOrigin.NotRead; }
                }

                int pages = (int)Math.Ceiling((double)dataInPage.Count() / size);
                ViewBag.Pages = pages;

                dataInPage = dataInPage.Skip((page - 1) * size).Take(size);
            }

            ViewBag.CurrentPage = page;
            ViewBag.CurrentFilter = filter;
            return View("~/Views/Home/Index.cshtml", dataInPage);
        }

        public IActionResult Profile()
        {
            return View("~/Views/Home/Profile.cshtml");
        }
    }
}