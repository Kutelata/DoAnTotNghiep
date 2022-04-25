using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.Admin.Controllers
{
    public partial class HomeController
    {
        [Authorize(Policy = "Admin and User Manager")]
        public async Task<IActionResult> CommentList(int page = 1, string search = null, string sort = "Id")
        {
            var allData = await _commentService.GetCommentStatistic();
            var dataInPage = allData;
            int size = 2;

            if (allData != null)
            {
                if (Request.Query.ContainsKey("sort"))
                {
                    var newSort = Request.Query["sort"].ToString();
                    sort = newSort;
                }
                if (sort != null)
                {
                    switch (sort)
                    {
                        case "Id": dataInPage = dataInPage.OrderBy(x => x.Id); break;
                        case "Text": dataInPage = dataInPage.OrderBy(x => x.Text); break;
                        case "ParentId": dataInPage = dataInPage.OrderBy(x => x.ParentId); break;
                        case "CreatedAt": dataInPage = dataInPage.OrderBy(x => x.CreatedAt); break;
                        case "ReviewId": dataInPage = dataInPage.OrderBy(x => x.ReviewId); break;
                        case "UserId": dataInPage = dataInPage.OrderBy(x => x.UserId); break;
                        case "UserName": dataInPage = dataInPage.OrderBy(x => x.UserName); break;
                        case "NumberCommentReplies": dataInPage = dataInPage.OrderBy(x => x.NumberCommentReplies); break;
                    }
                }

                if (Request.Query.ContainsKey("search"))
                {
                    var newSearch = Request.Query["search"].ToString();
                    search = newSearch;
                }
                if (search != null)
                {
                    dataInPage = dataInPage.Where(data =>
                        (data.Id.ToString() == search) ||
                        (data.Text != null && data.Text.Contains(search)) ||
                        (data.ParentId.ToString() == search) ||
                        data.CreatedAt.ToString().Contains(search) ||
                        (data.ReviewId.ToString() == search) ||
                        (data.UserId.ToString() == search) ||
                        (data.UserName != null && data.UserName.Contains(search)) ||
                        data.NumberCommentReplies.ToString() == search);
                }

                int pages = (int)Math.Ceiling((double)dataInPage.Count() / size);
                ViewBag.Pages = pages;

                if (Request.Query.ContainsKey("page"))
                {
                    var newPage = Convert.ToInt32(Request.Query["page"].ToString());
                    page = newPage;
                }
                if (page > pages)
                {
                    page = pages;
                }
                if (page <= 0)
                {
                    page = 1;
                }
                dataInPage = dataInPage.Skip((page - 1) * size).Take(size);
            }

            ViewBag.CurrentPage = page;
            ViewBag.CurrentSearch = search;
            ViewBag.CurrentSort = sort;
            return View("~/Views/Comment/Index.cshtml", dataInPage);
        }

        [Authorize(Policy = "Admin and User Manager")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var commentToDelete = await _commentService.GetById(id);
            var numberCommentReplies = await _commentService.GetByParentId(commentToDelete.ParentId);

            if (numberCommentReplies.Any())
            {
                TempData["Fail"] = "Delete Comment failed, still have parent id!";
                return RedirectToAction("CommentList", "Home");
            }
            if (commentToDelete != null)
            {
                int result = await _commentService.Delete(id);
                if (result != 0)
                {
                    TempData["Success"] = "Delete Comment success!";
                }
                else
                {
                    TempData["Fail"] = "Delete Comment failed!";
                }
                return RedirectToAction("CommentList", "Home");
            }
            return View("~/Views/Error/NotFound404.cshtml");
        }
    }
}
