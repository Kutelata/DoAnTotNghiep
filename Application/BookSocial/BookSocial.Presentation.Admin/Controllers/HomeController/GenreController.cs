using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.Admin.Controllers.HomeController
{
    public partial class HomeController
    {
        public async Task<IActionResult> GenreList(int page = 1, string search = null, string sort = "Name")
        {
            var allData = await _genreService.GetGenreStatistic();
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
                        case "Name": dataInPage = dataInPage.OrderBy(x => x.Name); break;
                        case "NumberOfBooks": dataInPage = dataInPage.OrderBy(x => x.NumberOfBooks); break;
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
                        data.Name.ToLower().Contains(search) ||
                        data.NumberOfBooks.ToString() == search);
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
            return View("~/Views/LibraryManager/Genre/Index.cshtml", dataInPage);
        }

        public async Task<IActionResult> CreateGenre()
        {
            return View();
        }
    }
}
