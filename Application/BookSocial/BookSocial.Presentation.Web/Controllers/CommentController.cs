using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookSocial.Presentation.User.Controllers
{
    public partial class HomeController
    {
        public async Task<IActionResult> CommentInReview(int reviewId, int page)
        {
            var comment = await _commentService.GetByReviewId(reviewId);
            IEnumerable<CommentInReview> dataInPage = null;
            int size = 2;

            if (comment != null)
            {
                dataInPage = _mapper.Map<IEnumerable<CommentInReview>>(comment);
                foreach (var data in dataInPage)
                {
                    data.User = await _userService.GetById(data.UserId);
                }

                dataInPage = dataInPage.Skip((page - 1) * size).Take(size).ToList();
            }

            return PartialView("~/Views/Review/Partials/CommentInReview.cshtml", dataInPage);
        }

        public async Task<IActionResult> CreateComment(Comment comment)
        {
            if (comment != null)
            {
                if (comment.Text != null && comment.Text != "")
                {
                    int result = await _commentService.Create(comment);
                    if (result != 0)
                    {
                        var commentAfterPost = await _commentService.GetById(result);
                        var convertCommentAfterPost = new List<CommentInReview>
                        {
                            _mapper.Map<CommentInReview>(commentAfterPost)
                        };
                        foreach (var data in convertCommentAfterPost)
                        {
                            data.User = await _userService.GetById(data.UserId);
                        }
                        return Json(new
                        {
                            currentPostComment = result,
                            model = PartialView("~/Views/Review/Partials/CommentInReview.cshtml", convertCommentAfterPost)
                        });
                    }
                    return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error!");
                }
                return StatusCode((int)HttpStatusCode.BadRequest, "Text is empty!");
            }
            return StatusCode((int)HttpStatusCode.BadRequest, "Bad request!");
        }

        public IActionResult EditComment()
        {
            return View("~/Views/Login.cshtml");
        }

        public IActionResult DeleteComment()
        {
            return View("~/Views/Login.cshtml");
        }
    }
}
