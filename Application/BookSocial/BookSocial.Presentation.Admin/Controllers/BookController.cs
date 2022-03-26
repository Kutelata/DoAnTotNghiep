using Microsoft.AspNetCore.Mvc;

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
                        data.Isbn.ToLower().Contains(search) ||
                        data.BookName.ToLower().Contains(search) ||
                        data.Image.ToLower().Contains(search) ||
                        data.Published.ToString().Contains(search) ||
                        data.GenreName.ToLower().Contains(search) ||
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

        //public IActionResult CreateBook()
        //{
        //    return View("~/Views/Book/Create.cshtml");
        //}

        //[HttpPost]
        //public async Task<ActionResult> CreateBook(Book Book)
        //{
        //    var checkNameUnique = await _bookService.GetByName(Book.Name);
        //    if (checkNameUnique != null)
        //    {
        //        ModelState.AddModelError("Name", "Book Name must be unique");
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        int result = await _BookService.Create(Book);
        //        if (result != 0)
        //        {
        //            TempData["Success"] = "Create Book success!";
        //        }
        //        else
        //        {
        //            TempData["Fail"] = "Create Book failed!";
        //        }
        //        return RedirectToAction("BookList", "Home");
        //    }
        //    return View("~/Views/Book/Create.cshtml", Book);

        //}

        //public async Task<IActionResult> EditBook(int id)
        //{
        //    var data = await _BookService.GetById(id);
        //    if (data != null)
        //    {
        //        return View("~/Views/Book/Edit.cshtml", data);
        //    }
        //    return RedirectToAction("NotFound404", "Route");
        //}

        //[HttpPost]
        //public async Task<IActionResult> EditBook(Book Book)
        //{
        //    var currentBook = await _BookService.GetById(Book.Id);
        //    var checkNameUnique = await _BookService.GetByName(Book.Name);
        //    if (checkNameUnique != null && checkNameUnique.Name != currentBook.Name)
        //    {
        //        ModelState.AddModelError("Name", "Book Name must be unique");
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        int result = await _BookService.Update(Book);
        //        if (result != 0)
        //        {
        //            TempData["Success"] = "Update Book success!";
        //        }
        //        else
        //        {
        //            TempData["Fail"] = "Update Book failed!";
        //        }
        //        return RedirectToAction("BookList", "Home");
        //    }
        //    return View("~/Views/Book/Edit.cshtml", Book);
        //}

        //public async Task<IActionResult> DeleteBook(int id)
        //{
        //    var data = await _BookService.GetById(id);
        //    if (data != null)
        //    {
        //        var checkBookExist = await _bookService.GetByBookId(id);
        //        if (checkBookExist == null)
        //        {
        //            int result = await _BookService.Delete(id);
        //            if (result != 0)
        //            {
        //                TempData["Success"] = "Delete Book success!";
        //            }
        //            else
        //            {
        //                TempData["Fail"] = "Delete Book failed!";
        //            }
        //        }
        //        else
        //        {
        //            TempData["Fail"] = "Delete Book failed, still books left!";
        //        }
        //        //Response.Headers.CacheControl = "no-cache";
        //        //Response.Headers.Pragma = "no-cache";
        //        //Response.Headers.Expires = "-1";
        //        return RedirectToAction("BookList", "Home");
        //    }
        //    return View("~/Views/Error/NotFound404.cshtml");
        //}
    }
}
