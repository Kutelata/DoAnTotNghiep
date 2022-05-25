using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;
using BookSocial.EntityClass.Enum;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookSocial.Presentation.Web.Controllers
{
    public partial class HomeController
    {
        public async Task<IActionResult> ReviewList(string stringReviewIdExclude)
        {
            var userIdClaim = User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
            var reviewLists = await _reviewService.GetReviewList();
            var shelfLists = await _shelfService.GetShelfListHomes(Convert.ToInt32(userIdClaim));
            var dataInPage = reviewLists.ToList();
            string[] listReviewIdExclude = stringReviewIdExclude?.Split(',');
            int[] convertListReviewIdExclude = Array.ConvertAll(listReviewIdExclude, s => int.Parse(s));
            int size = 2;

            if (reviewLists != null)
            {
                dataInPage =
                    (from item in dataInPage where !convertListReviewIdExclude.Contains(item.ReviewId) select item).ToList();

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

                dataInPage = dataInPage.Take(size).ToList();
            }

            return PartialView("~/Views/Review/Partials/ReviewList.cshtml", dataInPage);
        }

        public async Task<IActionResult> ReviewByBookId(int bookId, string stringReviewIdExclude)
        {
            var userIdClaim = User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
            var reviewByBookIds = _mapper.Map<List<ReviewByBookId>>(await _reviewService.GetByBookId(bookId));
            string[] listReviewIdExclude = stringReviewIdExclude?.Split(',');
            int[] convertListReviewIdExclude = Array.ConvertAll(listReviewIdExclude, s => int.Parse(s));
            int size = 2;

            if (reviewByBookIds.Any())
            {
                reviewByBookIds =
                    (from item in reviewByBookIds where !convertListReviewIdExclude.Contains(item.Id) select item)
                    .OrderByDescending(x => x.CreatedAt).ToList();

                reviewByBookIds = reviewByBookIds.Take(size).ToList();
                foreach (var review in reviewByBookIds)
                {
                    review.User = await _userService.GetById(review.UserId);
                    review.Shelf = await _shelfService.GetByBookAndUserId(bookId, review.UserId);
                }
            }
            return PartialView("~/Views/Review/Partials/ReviewByBookId.cshtml", reviewByBookIds);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview(Review review)
        {

            if (review != null)
            {
                if (review.Text != null && review.Text != "")
                {
                    int result = await _reviewService.Create(review);
                    if (result != 0)
                    {
                        var reviewAfterPost = await _reviewService.GetById(result);
                        var convertReviewAfterPost = new List<ReviewByBookId>
                        {
                            _mapper.Map<ReviewByBookId>(reviewAfterPost)
                        };

                        foreach (var data in convertReviewAfterPost)
                        {
                            data.User = await _userService.GetById(data.UserId);
                            data.Shelf = await _shelfService.GetByBookAndUserId(data.BookId, data.UserId);
                        }

                        return PartialView("~/Views/Review/Partials/ReviewByBookId.cshtml", convertReviewAfterPost);
                    }
                    return StatusCode((int)HttpStatusCode.InternalServerError, "Lỗi phía máy chủ!");
                }
                return StatusCode((int)HttpStatusCode.BadRequest, "Văn bản không được để rỗng!");
            }
            return StatusCode((int)HttpStatusCode.BadRequest, "Yêu cầu không hợp lệ!");
        }

        public async Task<IActionResult> DeleteReview(int reviewId)
        {
            if (reviewId != 0)
            {
                int result = await _reviewService.Delete(reviewId);
                if (result != 0)
                {
                    return Redirect(Request.Headers["Referer"].ToString());
                }
            }
            return View("~/Views/Error.cshtml");
        }
    }
}