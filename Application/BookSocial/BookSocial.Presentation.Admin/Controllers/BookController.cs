using BookSocial.EntityClass.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookSocial.Presentation.Admin.Controllers
{
    public partial class HomeController
    {
        public async Task<IActionResult> BookList(int page = 1, string search = null, string sort = "Isbn")
        {
            var allData = await _bookService.GetBookStatistic();
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
                        case "Isbn": dataInPage = dataInPage.OrderBy(x => x.Isbn); break;
                        case "BookName": dataInPage = dataInPage.OrderBy(x => x.BookName); break;
                        case "Image": dataInPage = dataInPage.OrderBy(x => x.Image); break;
                        case "Published": dataInPage = dataInPage.OrderBy(x => x.Published); break;
                        case "GenreName": dataInPage = dataInPage.OrderBy(x => x.GenreName); break;
                        case "NumberOfAuthors": dataInPage = dataInPage.OrderBy(x => x.NumberOfAuthors); break;
                        case "NumberOfArticles": dataInPage = dataInPage.OrderBy(x => x.NumberOfArticles); break;
                        case "NumberOfShelfs": dataInPage = dataInPage.OrderBy(x => x.NumberOfShelfs); break;
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
                        data.Isbn.Contains(search) ||
                        data.BookName.Contains(search) ||
                        (data.Image != null && data.Image.Contains(search)) ||
                        data.Published.ToString().Contains(search) ||
                        data.GenreName.Contains(search) ||
                        data.NumberOfAuthors.ToString() == search ||
                        data.NumberOfArticles.ToString() == search ||
                        data.NumberOfShelfs.ToString() == search);
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
            return View("~/Views/Book/Index.cshtml", dataInPage);
        }

        public async Task<IActionResult> CreateBook()
        {
            var genres = await _genreService.GetAll();
            ViewBag.Genres = new SelectList(genres, "Id", "Name");
            return View("~/Views/Book/Create.cshtml");
        }

        [HttpPost]
        public async Task<ActionResult> CreateBook(Book book, IFormFile Image)
        {
            var checkIsbnUnique = await _bookService.GetByIsbn(book.Isbn);
            if (checkIsbnUnique != null)
            {
                ModelState.AddModelError("Isbn", "Isbn book must be unique");
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
                        var pathBook = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\assets\images\book");
                        var imagePath = Path.Combine(pathBook, book.Image);
                        using (var stream = new FileStream(imagePath, FileMode.Create))
                        {
                            await Image.CopyToAsync(stream);
                        }
                    }
                    TempData["Success"] = "Create Book success!";
                }
                else
                {
                    TempData["Fail"] = "Create Book failed!";
                }
                return RedirectToAction("BookList", "Home");
            }
            var genres = await _genreService.GetAll();
            ViewBag.Genres = new SelectList(genres, "Id", "Name", book.GenreId);
            return View("~/Views/Book/Create.cshtml", book);
        }

        public async Task<IActionResult> EditBook(int id)
        {
            var data = await _bookService.GetById(id);
            if (data != null)
            {
                var genres = await _genreService.GetAll();
                ViewBag.Genres = new SelectList(genres, "Id", "Name", data.GenreId);
                return View("~/Views/Book/Edit.cshtml", data);
            }
            return RedirectToAction("NotFound404", "Route");
        }

        [HttpPost]
        public async Task<IActionResult> EditBook(Book book, IFormFile Image)
        {
            var currentBook = await _bookService.GetById(book.Id);
            var checkIsbnUnique = await _bookService.GetByIsbn(book.Isbn);
            if (checkIsbnUnique != null && currentBook.Isbn != book.Isbn)
            {
                ModelState.AddModelError("Isbn", "Isbn book must be unique");
            }
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    book.Image = $"{book.Isbn}.jpg";
                }
                else
                {
                    book.Image = currentBook.Image;
                }
                int result = await _bookService.Update(book);
                if (result != 0)
                {
                    if (Image != null && Image.Length > 0)
                    {
                        var pathBook = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\assets\images\book");
                        var imagePath = Path.Combine(pathBook, book.Image);
                        using (var stream = new FileStream(imagePath, FileMode.Create))
                        {
                            await Image.CopyToAsync(stream);
                        }
                    }
                    TempData["Success"] = "Edit Book success!";
                }
                else
                {
                    TempData["Fail"] = "Edit Book failed!";
                }
                return RedirectToAction("BookList", "Home");
            }
            var genres = await _genreService.GetAll();
            ViewBag.Genres = new SelectList(genres, "Id", "Name", book.GenreId);
            return View("~/Views/Book/Edit.cshtml", book);
        }

        public async Task<IActionResult> DeleteBook(int id)
        {
            var bookToDelete = await _bookService.GetById(id);
            var authorAssignToBook = await _authorBookService.GetByBookId(id);
            var articleHaveBook = await _articleService.GetByBookId(id);
            var shelfHaveBook = await _shelfService.GetByBookId(id);

            if (authorAssignToBook.Any())
            {
                TempData["Fail"] = "Delete Book failed, still assigned to author!";
                return RedirectToAction("BookList", "Home");
            }
            if (articleHaveBook.Any())
            {
                TempData["Fail"] = "Delete Book failed, still have article!";
                return RedirectToAction("BookList", "Home");
            }
            if (shelfHaveBook.Any())
            {
                TempData["Fail"] = "Delete Book failed, still have shelf!";
                return RedirectToAction("BookList", "Home");
            }
            if (bookToDelete != null)
            {
                int result = await _bookService.Delete(id);
                if (result != 0)
                {
                    if (!string.IsNullOrEmpty(bookToDelete.Image))
                    {
                        var pathBook = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\assets\images\book");
                        var imagePath = Path.Combine(pathBook, bookToDelete.Image);
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }
                    }
                    TempData["Success"] = "Delete Book success!";
                }
                else
                {
                    TempData["Fail"] = "Delete Book failed!";
                }
                return RedirectToAction("BookList", "Home");
            }
            return View("~/Views/Error/NotFound404.cshtml");
        }
    }
}
