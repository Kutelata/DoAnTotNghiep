using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.User.Controllers
{
    public partial class HomeController
    {
        public async Task<IActionResult> ShelfList(int userId, int page = 1, string search = null, string sort = "UserId")
        {
            var allData = await _shelfService.GetByShelfDetail(userId);
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
                        case "UserId": dataInPage = dataInPage.OrderBy(x => x.UserId); break;
                        case "GenreId": dataInPage = dataInPage.OrderBy(x => x.GenreId); break;
                        case "GenreName": dataInPage = dataInPage.OrderBy(x => x.GenreName); break;
                        case "BookId": dataInPage = dataInPage.OrderBy(x => x.BookId); break;
                        case "BookName": dataInPage = dataInPage.OrderBy(x => x.BookName); break;
                        case "BookImage": dataInPage = dataInPage.OrderBy(x => x.BookImage); break;
                        case "BookDescription": dataInPage = dataInPage.OrderBy(x => x.BookDescription); break;
                        case "ProgressRead": dataInPage = dataInPage.OrderBy(x => x.ProgressRead); break;
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
                        (data.UserId.ToString() == search) ||
                        (data.GenreId.ToString() == search) ||
                        (data.GenreName != null && data.GenreName.Contains(search)) ||
                        (data.BookId.ToString() == search) ||
                        (data.BookName != null && data.BookName.Contains(search)) ||
                        (data.BookImage != null && data.BookImage.Contains(search)) ||
                        (data.BookDescription != null && data.BookDescription.Contains(search)) ||
                        data.ProgressRead.ToString() == search);
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
            return View("~/Views/Shelf/Index.cshtml", dataInPage);
        }
    }
}
