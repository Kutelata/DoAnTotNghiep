using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;
using BookSocial.EntityClass.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookSocial.Presentation.Web.Controllers
{
    public partial class HomeController
    {
        public async Task<IActionResult> BookProfile(int bookId)
        {
            var book = await _bookService.GetById(bookId);
            var userIdClaim = User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
            var page = 1;
            var size = 2;
            if (book != null)
            {
                var convertBook = _mapper.Map<BookProfile>(book);
                convertBook.Genre = await _genreService.GetById(convertBook.GenreId);
                convertBook.AuthorListByBookId = (List<AuthorListByBookId>)await _authorService.GetAuthorListByBookId(convertBook.Id);
                var reviewByBookIds = _mapper.Map<List<ReviewByBookId>>(await _reviewService.GetByBookId(convertBook.Id));
                
                int count = 0;
                foreach (var review in reviewByBookIds)
                {
                    if ((double)review.Star != 0)
                    {
                        count++;
                        convertBook.AverageOfStar += (double)review.Star;
                    }
                }
                convertBook.AverageOfStar /= count;
                convertBook.ReviewByBookId = reviewByBookIds.OrderByDescending(x => x.CreatedAt).Skip((page - 1) * size).Take(size).ToList();

                var checkBookInShelf = await _shelfService.GetByBookAndUserId(book.Id, Convert.ToInt32(userIdClaim));
                if (checkBookInShelf != null)
                {
                    convertBook.UserClaimProgressRead = (ProgressReadOrigin)checkBookInShelf.ProgressRead;
                }
                else { convertBook.UserClaimProgressRead = ProgressReadOrigin.NotRead; }

                foreach (var review in convertBook.ReviewByBookId)
                {
                    review.User = await _userService.GetById(review.UserId);
                    review.Shelf = await _shelfService.GetByBookAndUserId(book.Id, review.UserId);
                }
                return View("~/Views/Book/Index.cshtml", convertBook);
            }
            return View("~/Views/Error.cshtml");
        }

        public async Task<IActionResult> CreateBook()
        {
            var genres = await _genreService.GetAll();
            ViewBag.Genres = new SelectList(genres, "Id", "Name");
            return View("~/Views/Search/CreateBook.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(Book book, IFormFile Image)
        {
            var userIdClaim = User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
            var checkIsbnUnique = await _bookService.GetByIsbn(book.Isbn);
            double numberBooksOnShelf = await _shelfService.GetTotalReadByUserId(Convert.ToInt32(userIdClaim));
            if (numberBooksOnShelf < 10)
            {
                ModelState.AddModelError(String.Empty, "Người dùng phải đọc tối thiểu 10 cuốn sách mới có quyền thêm sách!");
            }
            if (checkIsbnUnique != null)
            {
                ModelState.AddModelError("Isbn", "Mã Isbn của sách bị trùng!");
            }
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    book.Image = $"{book.Isbn}.jpg";
                }
                int result = await _bookService.Create(book);
                if (result != 0)
                {
                    if (Image != null && Image.Length > 0)
                    {
                        var pathBook = Path.Combine(
                            Directory.GetParent(Directory.GetCurrentDirectory()).FullName,
                            @"BookSocial.Presentation.Cms\wwwroot\assets\images\book");
                        var imagePath = Path.Combine(pathBook, book.Image);
                        using (var stream = new FileStream(imagePath, FileMode.Create))
                        {
                            await Image.CopyToAsync(stream);
                        }
                    }
                    TempData["Success"] = "Thêm sách thành công!";
                }
                else
                {
                    TempData["Fail"] = "Thêm sách thất bại!";
                }
                return RedirectToAction("BookProfile", "Home", new { bookId = result });
            }
            var genres = await _genreService.GetAll();
            ViewBag.Genres = new SelectList(genres, "Id", "Name", book.GenreId);
            return View("~/Views/Search/CreateBook.cshtml", book);
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