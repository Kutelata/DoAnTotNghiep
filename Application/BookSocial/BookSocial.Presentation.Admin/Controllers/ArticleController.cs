using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.Admin.Controllers
{
    public partial class HomeController
    {
        public async Task<IActionResult> ArticleList(int page = 1, string search = null, string sort = "Id")
        {
            var allData = await _articleService.GetArticleStatistic();
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
                        case "Star": dataInPage = dataInPage.OrderBy(x => x.Star); break;
                        case "CreatedAt": dataInPage = dataInPage.OrderBy(x => x.CreatedAt); break;
                        case "BookId": dataInPage = dataInPage.OrderBy(x => x.BookId); break;
                        case "BookName": dataInPage = dataInPage.OrderBy(x => x.BookName); break;
                        case "UserId": dataInPage = dataInPage.OrderBy(x => x.UserId); break;
                        case "UserName": dataInPage = dataInPage.OrderBy(x => x.UserName); break;
                        case "NumberOfComments": dataInPage = dataInPage.OrderBy(x => x.NumberOfComments); break;
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
                        (data.Star.ToString() == search) ||
                        data.CreatedAt.ToString().Contains(search) ||
                        (data.BookId.ToString() == search) ||
                        (data.BookName != null && data.BookName.Contains(search)) ||
                        (data.UserId.ToString() == search) ||
                        (data.UserName != null && data.UserName.Contains(search)) ||
                        data.NumberOfComments.ToString() == search);
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
            return View("~/Views/Article/Index.cshtml", dataInPage);
        }

        public async Task<IActionResult> DeleteArticle(int id)
        {
            var articleToDelete = await _articleService.GetById(id);
            var numberOfComments = await _commentService.GetByArticleId(id);

            if (numberOfComments.Any())
            {
                TempData["Fail"] = "Delete Article failed, still have comments!";
                return RedirectToAction("ArticleList", "Home");
            }
            if (articleToDelete != null)
            {
                int result = await _articleService.Delete(id);
                if (result != 0)
                {
                    TempData["Success"] = "Delete Article success!";
                }
                else
                {
                    TempData["Fail"] = "Delete Article failed!";
                }
                return RedirectToAction("ArticleList", "Home");
            }
            return View("~/Views/Error/NotFound404.cshtml");
        }
    }
}
