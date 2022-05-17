using BookSocial.EntityClass.Enum;
using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.User.Controllers
{
    public partial class HomeController
    {
        public async Task<IActionResult> ReviewList(int page)
        {
            var userIdClaim = User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
            var reviewLists = await _reviewService.GetReviewList();
            var shelfLists = await _shelfService.GetShelfListHomes(Convert.ToInt32(userIdClaim));
            var dataInPage = reviewLists.ToList();
            int size = 2;

            if (reviewLists != null)
            {
                foreach (var data in dataInPage)
                {
                    data.AuthorListByBookId = await _authorService.GetAuthorListByBookId(data.BookId);
                    var checkBookInShelf = await _shelfService.GetByBookAndUserId(data.BookId, Convert.ToInt32(userIdClaim));
                    if (checkBookInShelf != null)
                    {
                        data.UserClaimProgressRead = (ProgressReadOrigin)checkBookInShelf.ProgressRead;
                    }
                    else { data.UserClaimProgressRead = ProgressReadOrigin.NotRead; }
                }

                dataInPage = dataInPage.Skip((page - 1) * size).Take(size).ToList();
            }

            return PartialView("~/Views/Review/Partials/ReviewList.cshtml", dataInPage);
        }

        public IActionResult CreateReview()
        {
            return View("~/Views/Login.cshtml");
        }

        public IActionResult EditReview()
        {
            return View("~/Views/Login.cshtml");
        }

        public IActionResult DeleteReview()
        {
            return View("~/Views/Login.cshtml");
        }
    }
}
