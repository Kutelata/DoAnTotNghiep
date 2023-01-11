using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Net;
using System.Numerics;
using System.Reflection;

namespace BookSocial.Presentation.Web.Controllers
{
    public partial class HomeController
    {
        public async Task<IActionResult> CommentInReview(int reviewId, int page, string stringCommentIdExclude)
        {
            var comments = await _commentService.GetByReviewId(reviewId);
            string[] listCommentIdExclude = stringCommentIdExclude?.Split(',');
            List<CommentInReview> dataInPage = null;
            int size = 2;
            bool isMoreData = true;

            if (comments != null)
            {
                dataInPage = _mapper.Map<List<CommentInReview>>(comments);
                int totalPage = (int)Math.Ceiling((double)dataInPage.Count() / 2);
                foreach (var data in dataInPage.ToList())
                {
                    data.User = await _userService.GetById(data.UserId);
                    if (listCommentIdExclude != null && listCommentIdExclude.Length != 0)
                    {
                        foreach (var commentId in listCommentIdExclude)
                        {
                            if (Convert.ToInt32(commentId) == data.Id)
                            {
                                dataInPage.Remove(data);
                            }
                        }
                    }
                }

                dataInPage = dataInPage.Skip((page - 1) * size).Take(size).ToList();
                if (totalPage == page)
                {
                    isMoreData = false;
                }
            }
            if (dataInPage != null && dataInPage.Count != 0)
            {
                var htmlData = _viewRenderService.RenderToStringAsync("~/Views/Review/Partials/CommentInReview.cshtml", dataInPage);
                object jsonData = new
                {
                    isMoreData,
                    partialView = htmlData
                };
                return Json(jsonData);
            }
            return null;
        }

        public string ConvertViewToString(ControllerContext controllerContext, PartialViewResult pvr, ICompositeViewEngine _viewEngine)
        {
            using StringWriter writer = new();
            ViewEngineResult vResult = _viewEngine.FindView(controllerContext, pvr.ViewName, false);
            ViewContext viewContext = new(controllerContext, vResult.View, pvr.ViewData, pvr.TempData, writer, new HtmlHelperOptions());

            vResult.View.RenderAsync(viewContext);

            return writer.GetStringBuilder().ToString();
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
                            data.Id = result;
                            data.User = await _userService.GetById(data.UserId);
                            data.Action = "Insert";
                        }

                        return PartialView("~/Views/Review/Partials/CommentInReview.cshtml", convertCommentAfterPost);
                    }
                    return StatusCode((int)HttpStatusCode.InternalServerError, "Lỗi phía máy chủ!");
                }
                return StatusCode((int)HttpStatusCode.BadRequest, "Văn bản không được để rỗng!");
            }
            return StatusCode((int)HttpStatusCode.BadRequest, "Yêu cầu không hợp lệ!");
        }

        public async Task<IActionResult> DeleteComment(int commentId)
        {
            if (commentId != 0)
            {
                int result = await _commentService.Delete(commentId);
                if (result != 0)
                {
                    return Ok();
                }
            }
            return StatusCode((int)HttpStatusCode.BadRequest, "Yêu cầu không hợp lệ!");
        }
    }
}