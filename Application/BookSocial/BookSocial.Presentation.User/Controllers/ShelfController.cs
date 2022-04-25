using BookSocial.EntityClass.Entity;
using BookSocial.EntityClass.Enum;
using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.User.Controllers
{
    public partial class HomeController
    {
        public async Task<IActionResult> ShelfList(int page = 1, string search = null, string filter = null)
        {
            var userIdClaim = User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
            var allData = await _shelfService.GetByShelfDetail(Convert.ToInt32(userIdClaim));
            var dataInPage = allData;
            int size = 2;

            if (allData != null)
            {
                if (Request.Query.ContainsKey("filter"))
                {
                    if (Request.Query["filter"].ToString() != null && Request.Query["filter"].ToString() != "")
                    {
                        var isNumeric = int.TryParse(Request.Query["filter"].ToString(), out int number);
                        if (isNumeric)
                        {
                            filter = Request.Query["filter"].ToString();
                        }
                        else
                        {
                            filter = "-1";
                        }
                    }
                }
                if (filter != null && filter != "")
                {
                    switch (Convert.ToInt32(filter))
                    {
                        case (int)ProgressRead.WantToRead:
                            dataInPage = dataInPage.Where(x => (int)x.ProgressRead == Convert.ToInt32(filter)); break;
                        case (int)ProgressRead.CurrentlyReading:
                            dataInPage = dataInPage.Where(x => (int)x.ProgressRead == Convert.ToInt32(filter)); break;
                        case (int)ProgressRead.Read:
                            dataInPage = dataInPage.Where(x => (int)x.ProgressRead == Convert.ToInt32(filter)); break;
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
            ViewBag.CurrentFilter = filter;
            return View("~/Views/Shelf/Index.cshtml", dataInPage);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeProgressRead(Shelf shelf)
        {
            if (shelf != null)
            {
                var result = await _shelfService.Update(shelf);
                if (result != 0)
                {
                    return StatusCode(200);
                }
                return StatusCode(500);
            }
            return StatusCode(400);
        }
    }
}