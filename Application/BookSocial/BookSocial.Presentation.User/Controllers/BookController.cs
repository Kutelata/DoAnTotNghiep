using BookSocial.EntityClass.Entity;
using BookSocial.EntityClass.Enum;
using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.User.Controllers
{
    public partial class HomeController
    {
        public async Task<IActionResult> BookProfile(int bookId)
        {

            return View("~/Views/Book/Index.cshtml");
        }

        public async Task<IActionResult> SearchBook(int page = 1, string search = null)
        {
            var userIdClaim = User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
            var allData = await _bookService.GetSearchBook();
            var dataInPage = allData;
            int size = 2;

            if (allData != null)
            {
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
                        data.NumberOfReviews.ToString() == search ||
                        data.AverageOfRating.ToString() == search);
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

            ViewBag.CurrentPage = page;
            ViewBag.CurrentSearch = search;
            return View("~/Views/Search/SearchByBook.cshtml", dataInPage);
        }
    }
}