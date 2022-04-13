using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace BookSocial.Presentation.Admin.Controllers
{
    public partial class HomeController
    {
        public async Task<IActionResult> EmployeeList(int page = 1, string search = null, string sort = "Id")
        {
            var allData = await _userService.GetUserEmployeeStatistic();
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
                        case "UserName": dataInPage = dataInPage.OrderBy(x => x.UserName); break;
                        case "Account": dataInPage = dataInPage.OrderBy(x => x.Account); break;
                        case "Image": dataInPage = dataInPage.OrderBy(x => x.Image); break;
                        case "Status": dataInPage = dataInPage.OrderBy(x => x.Status); break;
                        case "Role": dataInPage = dataInPage.OrderBy(x => x.Role); break;
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
                        (data.UserName != null && data.UserName.Contains(search)) ||
                        (data.Account != null && data.Account.Contains(search)) ||
                        (data.Image != null && data.Image.Contains(search)) ||
                        data.Status.ToString() == search ||
                        data.Role.ToString() == search);
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
            return View("~/Views/User/Admin/Index.cshtml", dataInPage);
        }

        public async Task<IActionResult> ExportEmployeeToCsv()
        {
            var data = await _userService.GetUserEmployeeStatistic();

            using (var memoryStream = new MemoryStream())
            {
                using (var streamWriter = new StreamWriter(memoryStream))
                using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                {
                    csvWriter.WriteRecords(data);
                }
                return File(memoryStream.ToArray(), "text/csv", "UserEmployeeReports.csv");
            }
        }

        public async Task<IActionResult> CreateEmployee()
        {
            return View("~/Views/User/Admin/Create.cshtml");
        }

        //[HttpPost]
        //public async Task<ActionResult> CreateBook(Book book, IFormFile Image)
        //{
        //    var checkIsbnUnique = await _bookService.GetByIsbn(book.Isbn);
        //    if (checkIsbnUnique != null)
        //    {
        //        ModelState.AddModelError("Isbn", "Isbn book must be unique");
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        if (Image != null)
        //        {
        //            book.Image = $"{book.Isbn}.jpg";
        //        }
        //        int result = await _bookService.Create(book);
        //        if (result != 0)
        //        {
        //            if (Image != null && Image.Length > 0)
        //            {
        //                var pathBook = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\assets\images\book");
        //                var imagePath = Path.Combine(pathBook, book.Image);
        //                using (var stream = new FileStream(imagePath, FileMode.Create))
        //                {
        //                    await Image.CopyToAsync(stream);
        //                }
        //            }
        //            TempData["Success"] = "Create Book success!";
        //        }
        //        else
        //        {
        //            TempData["Fail"] = "Create Book failed!";
        //        }
        //        return RedirectToAction("BookList", "Home");
        //    }
        //    var genres = await _genreService.GetAll();
        //    ViewBag.Genres = new SelectList(genres, "Id", "Name", book.GenreId);
        //    return View("~/Views/Book/Create.cshtml", book);
        //}

        //public async Task<IActionResult> EditBook(int id)
        //{
        //    var data = await _bookService.GetById(id);
        //    if (data != null)
        //    {
        //        var genres = await _genreService.GetAll();
        //        ViewBag.Genres = new SelectList(genres, "Id", "Name", data.GenreId);
        //        return View("~/Views/Book/Edit.cshtml", data);
        //    }
        //    return RedirectToAction("NotFound404", "Route");
        //}

        //[HttpPost]
        //public async Task<IActionResult> EditBook(Book book, IFormFile Image)
        //{
        //    var currentBook = await _bookService.GetById(book.Id);
        //    var checkIsbnUnique = await _bookService.GetByIsbn(book.Isbn);
        //    if (checkIsbnUnique != null && currentBook.Isbn != book.Isbn)
        //    {
        //        ModelState.AddModelError("Isbn", "Isbn book must be unique");
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        if (Image != null)
        //        {
        //            book.Image = $"{book.Isbn}.jpg";
        //        }
        //        else
        //        {
        //            book.Image = currentBook.Image;
        //        }
        //        int result = await _bookService.Update(book);
        //        if (result != 0)
        //        {
        //            if (Image != null && Image.Length > 0)
        //            {
        //                var pathBook = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\assets\images\book");
        //                var imagePath = Path.Combine(pathBook, book.Image);
        //                using (var stream = new FileStream(imagePath, FileMode.Create))
        //                {
        //                    await Image.CopyToAsync(stream);
        //                }
        //            }
        //            TempData["Success"] = "Edit Book success!";
        //            return RedirectToAction("BookList", "Home", new { search = book.Id });
        //        }
        //        else
        //        {
        //            TempData["Fail"] = "Edit Book failed!";
        //            return RedirectToAction("BookList", "Home");
        //        }
        //    }
        //    var genres = await _genreService.GetAll();
        //    ViewBag.Genres = new SelectList(genres, "Id", "Name", book.GenreId);
        //    return View("~/Views/Book/Edit.cshtml", book);
        //}

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var userToDelete = await _userService.GetById(id);
           
            if (userToDelete != null)
            {
                int result = await _userService.Delete(id);
                if (result != 0)
                {
                    TempData["Success"] = "Delete Employee success!";
                }
                else
                {
                    TempData["Fail"] = "Delete Employee failed!";
                }
                return RedirectToAction("EmployeeList", "Home");
            }
            return View("~/Views/Error/NotFound404.cshtml");
        }
    }
}
