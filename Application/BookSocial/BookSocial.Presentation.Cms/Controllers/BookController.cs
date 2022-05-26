using BookSocial.EntityClass.Entity;
using CsvHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;

namespace BookSocial.Presentation.Cms.Controllers
{
    public partial class HomeController
    {
        [Authorize(Policy = "Admin and Library Manager")]
        public async Task<IActionResult> BookList(int page = 1, string search = null, string sort = "Id")
        {
            var allData = await _bookService.GetBookStatistic();
            var dataInPage = allData;
            int size = 5;

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
                        case "Isbn": dataInPage = dataInPage.OrderBy(x => x.Isbn); break;
                        case "BookName": dataInPage = dataInPage.OrderBy(x => x.BookName); break;
                        case "Image": dataInPage = dataInPage.OrderBy(x => x.Image); break;
                        case "Published": dataInPage = dataInPage.OrderBy(x => x.Published); break;
                        case "GenreName": dataInPage = dataInPage.OrderBy(x => x.GenreName); break;
                        case "NumberOfAuthors": dataInPage = dataInPage.OrderBy(x => x.NumberOfAuthors); break;
                        case "NumberOfReviews": dataInPage = dataInPage.OrderBy(x => x.NumberOfReviews); break;
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
                        (data.Id.ToString() == search) ||
                        (data.Isbn != null && data.Isbn.Contains(search)) ||
                        (data.BookName != null && data.BookName.Contains(search)) ||
                        (data.Image != null && data.Image.Contains(search)) ||
                        data.Published.ToString().Contains(search) ||
                        (data.GenreName != null && data.GenreName.Contains(search)) ||
                        data.NumberOfAuthors.ToString() == search ||
                        data.NumberOfReviews.ToString() == search ||
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
            ViewBag.CurrentSort = sort;
            return View("~/Views/Book/Index.cshtml", dataInPage);
        }

        [Authorize(Policy = "Admin and Library Manager")]
        public async Task<IActionResult> ExportBookToCsv()
        {
            var data = await _bookService.GetBookStatistic();

            using (var memoryStream = new MemoryStream())
            {
                using (var streamWriter = new StreamWriter(memoryStream))
                using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                {
                    csvWriter.WriteRecords(data);
                }
                return File(memoryStream.ToArray(), "text/csv", "BookReports.csv");
            }
        }

        [Authorize(Policy = "Admin and Library Manager")]
        public async Task<IActionResult> DetailBook(int id)
        {
            var dataBook = await _bookService.GetById(id);
            if (dataBook != null)
            {
                List<Author> authors = new();
                var authorAssignToBook = await _authorBookService.GetByBookId(id);
                foreach (var authorId in authorAssignToBook)
                {
                    var author = await _authorService.GetById(authorId.AuthorId);
                    authors.Add(author);
                }
                ViewData["AuthorByBookId"] = authors;
                ViewData["GenreByBookId"] = await _genreService.GetById(dataBook.GenreId);
                return View("~/Views/Book/Detail.cshtml", dataBook);
            }
            return RedirectToAction("NotFound404", "Route");
        }

        [Authorize(Policy = "Admin and Library Manager")]
        public async Task<IActionResult> CreateBook()
        {
            var genres = await _genreService.GetAll();
            ViewBag.Genres = new SelectList(genres, "Id", "Name");
            return View("~/Views/Book/Create.cshtml");
        }

        [Authorize(Policy = "Admin and Library Manager")]
        [HttpPost]
        public async Task<ActionResult> CreateBook(Book book, IFormFile Image)
        {
            var checkIsbnUnique = await _bookService.GetByIsbn(book.Isbn);
            if (checkIsbnUnique != null)
            {
                ModelState.AddModelError("Isbn", "Mã Isbn không được phép trùng");
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
                    TempData["Success"] = "Thêm sách thành công!";
                }
                else
                {
                    TempData["Fail"] = "Thêm sách thất bại!";
                }
                return RedirectToAction("BookList", "Home");
            }
            var genres = await _genreService.GetAll();
            ViewBag.Genres = new SelectList(genres, "Id", "Name", book.GenreId);
            return View("~/Views/Book/Create.cshtml", book);
        }

        [Authorize(Policy = "Admin and Library Manager")]
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

        [Authorize(Policy = "Admin and Library Manager")]
        [HttpPost]
        public async Task<IActionResult> EditBook(Book book, IFormFile Image)
        {
            var currentBook = await _bookService.GetById(book.Id);
            var checkIsbnUnique = await _bookService.GetByIsbn(book.Isbn);
            if (checkIsbnUnique != null && currentBook.Isbn != book.Isbn)
            {
                ModelState.AddModelError("Isbn", "Mã Isbn không được trùng");
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
                    TempData["Success"] = "Sửa sách thành công!";
                    return RedirectToAction("BookList", "Home", new { search = book.Id });
                }
                else
                {
                    TempData["Fail"] = "Sửa sách thất bại!";
                    return RedirectToAction("BookList", "Home");
                }
            }
            var genres = await _genreService.GetAll();
            ViewBag.Genres = new SelectList(genres, "Id", "Name", book.GenreId);
            return View("~/Views/Book/Edit.cshtml", book);
        }

        [Authorize(Policy = "Admin and Library Manager")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var bookToDelete = await _bookService.GetById(id);
            var authorAssignToBook = await _authorBookService.GetByBookId(id);
            var reviewHaveBook = await _reviewService.GetByBookId(id);
            var shelfHaveBook = await _shelfService.GetByBookId(id);

            if (authorAssignToBook.Any())
            {
                TempData["Fail"] = "Xóa sách thất bại, vẫn đang được gán cho tác giả!";
                return RedirectToAction("BookList", "Home");
            }
            if (reviewHaveBook.Any())
            {
                TempData["Fail"] = "Xóa sách thất bại, vẫn chứa đánh giá!";
                return RedirectToAction("BookList", "Home");
            }
            if (shelfHaveBook.Any())
            {
                TempData["Fail"] = "Xóa sách thất bại, vẫn tồn tại ở giá sách người dùng!";
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
                    TempData["Success"] = "Xóa sách thành công!";
                }
                else
                {
                    TempData["Fail"] = "Xóa sách thất bại!";
                }
                return RedirectToAction("BookList", "Home");
            }
            return RedirectToAction("NotFound404", "Route");
        }
    }
}
