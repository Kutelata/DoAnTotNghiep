using BookSocial.EntityClass.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.Admin.Controllers
{
    public partial class HomeController
    {
        //public async Task<IActionResult> UserList(int page = 1, string search = null, string sort = "Id")
        //{
        //    var allData = await _userService.
        //    var dataInPage = allData;
        //    int size = 2;

        //    if (allData != null)
        //    {
        //        if (Request.Query.ContainsKey("sort"))
        //        {
        //            var newSort = Request.Query["sort"].ToString();
        //            sort = newSort;
        //        }
        //        if (sort != null)
        //        {
        //            switch (sort)
        //            {
        //                case "Id": dataInPage = dataInPage.OrderBy(x => x.Id); break;
        //                case "Isbn": dataInPage = dataInPage.OrderBy(x => x.Isbn); break;
        //                case "UserName": dataInPage = dataInPage.OrderBy(x => x.UserName); break;
        //                case "Image": dataInPage = dataInPage.OrderBy(x => x.Image); break;
        //                case "Published": dataInPage = dataInPage.OrderBy(x => x.Published); break;
        //                case "GenreName": dataInPage = dataInPage.OrderBy(x => x.GenreName); break;
        //                case "NumberOfAuthors": dataInPage = dataInPage.OrderBy(x => x.NumberOfAuthors); break;
        //                case "NumberOfArticles": dataInPage = dataInPage.OrderBy(x => x.NumberOfArticles); break;
        //                case "NumberOfShelfs": dataInPage = dataInPage.OrderBy(x => x.NumberOfShelfs); break;
        //            }
        //        }

        //        if (Request.Query.ContainsKey("search"))
        //        {
        //            var newSearch = Request.Query["search"].ToString();
        //            search = newSearch;
        //        }
        //        if (search != null)
        //        {
        //            dataInPage = dataInPage.Where(data =>
        //                (data.Id.ToString() == search) ||
        //                (data.Isbn != null && data.Isbn.Contains(search)) ||
        //                (data.UserName != null && data.UserName.Contains(search)) ||
        //                (data.Image != null && data.Image.Contains(search)) ||
        //                data.Published.ToString().Contains(search) ||
        //                (data.GenreName != null && data.GenreName.Contains(search)) ||
        //                data.NumberOfAuthors.ToString() == search ||
        //                data.NumberOfArticles.ToString() == search ||
        //                data.NumberOfShelfs.ToString() == search);
        //        }

        //        int pages = (int)Math.Ceiling((double)dataInPage.Count() / size);
        //        ViewBag.Pages = pages;

        //        if (Request.Query.ContainsKey("page"))
        //        {
        //            var newPage = Convert.ToInt32(Request.Query["page"].ToString());
        //            page = newPage;
        //        }
        //        if (page > pages)
        //        {
        //            page = pages;
        //        }
        //        if (page <= 0)
        //        {
        //            page = 1;
        //        }
        //        dataInPage = dataInPage.Skip((page - 1) * size).Take(size);
        //    }

        //    ViewBag.CurrentPage = page;
        //    ViewBag.CurrentSearch = search;
        //    return View("~/Views/User/Index.cshtml", dataInPage);
        //}

        //public async Task<IActionResult> ExportUserToCsv()
        //{
        //    var data = await _UserService.GetUserStatistic();

        //    using (var memoryStream = new MemoryStream())
        //    {
        //        using (var streamWriter = new StreamWriter(memoryStream))
        //        using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
        //        {
        //            csvWriter.WriteRecords(data);
        //        }
        //        return File(memoryStream.ToArray(), "text/csv", "Reports.csv");
        //    }
        //}

        //public async Task<IActionResult> DetailUser(int id)
        //{
        //    var dataUser = await _UserService.GetById(id);
        //    if (dataUser != null)
        //    {
        //        List<Author> authors = new();
        //        var authorAssignToUser = await _authorUserService.GetByUserId(id);
        //        foreach (var authorId in authorAssignToUser)
        //        {
        //            var author = await _authorService.GetById(authorId.AuthorId);
        //            authors.Add(author);
        //        }
        //        ViewData["AuthorByUserId"] = authors;
        //        ViewData["GenreByUserId"] = await _genreService.GetById(dataUser.GenreId);
        //        return View("~/Views/User/Detail.cshtml", dataUser);
        //    }
        //    return RedirectToAction("NotFound404", "Route");
        //}

        //public async Task<IActionResult> CreateUser()
        //{
        //    var genres = await _genreService.GetAll();
        //    ViewBag.Genres = new SelectList(genres, "Id", "Name");
        //    return View("~/Views/User/Create.cshtml");
        //}

        //[HttpPost]
        //public async Task<ActionResult> CreateUser(User User, IFormFile Image)
        //{
        //    var checkIsbnUnique = await _UserService.GetByIsbn(User.Isbn);
        //    if (checkIsbnUnique != null)
        //    {
        //        ModelState.AddModelError("Isbn", "Isbn User must be unique");
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        if (Image != null)
        //        {
        //            User.Image = $"{User.Isbn}.jpg";
        //        }
        //        int result = await _UserService.Create(User);
        //        if (result != 0)
        //        {
        //            if (Image != null && Image.Length > 0)
        //            {
        //                var pathUser = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\assets\images\User");
        //                var imagePath = Path.Combine(pathUser, User.Image);
        //                using (var stream = new FileStream(imagePath, FileMode.Create))
        //                {
        //                    await Image.CopyToAsync(stream);
        //                }
        //            }
        //            TempData["Success"] = "Create User success!";
        //        }
        //        else
        //        {
        //            TempData["Fail"] = "Create User failed!";
        //        }
        //        return RedirectToAction("UserList", "Home");
        //    }
        //    var genres = await _genreService.GetAll();
        //    ViewBag.Genres = new SelectList(genres, "Id", "Name", User.GenreId);
        //    return View("~/Views/User/Create.cshtml", User);
        //}

        //public async Task<IActionResult> EditUser(int id)
        //{
        //    var data = await _UserService.GetById(id);
        //    if (data != null)
        //    {
        //        var genres = await _genreService.GetAll();
        //        ViewBag.Genres = new SelectList(genres, "Id", "Name", data.GenreId);
        //        return View("~/Views/User/Edit.cshtml", data);
        //    }
        //    return RedirectToAction("NotFound404", "Route");
        //}

        //[HttpPost]
        //public async Task<IActionResult> EditUser(User User, IFormFile Image)
        //{
        //    var currentUser = await _UserService.GetById(User.Id);
        //    var checkIsbnUnique = await _UserService.GetByIsbn(User.Isbn);
        //    if (checkIsbnUnique != null && currentUser.Isbn != User.Isbn)
        //    {
        //        ModelState.AddModelError("Isbn", "Isbn User must be unique");
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        if (Image != null)
        //        {
        //            User.Image = $"{User.Isbn}.jpg";
        //        }
        //        else
        //        {
        //            User.Image = currentUser.Image;
        //        }
        //        int result = await _UserService.Update(User);
        //        if (result != 0)
        //        {
        //            if (Image != null && Image.Length > 0)
        //            {
        //                var pathUser = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\assets\images\User");
        //                var imagePath = Path.Combine(pathUser, User.Image);
        //                using (var stream = new FileStream(imagePath, FileMode.Create))
        //                {
        //                    await Image.CopyToAsync(stream);
        //                }
        //            }
        //            TempData["Success"] = "Edit User success!";
        //            return RedirectToAction("UserList", "Home", new { search = User.Id });
        //        }
        //        else
        //        {
        //            TempData["Fail"] = "Edit User failed!";
        //            return RedirectToAction("UserList", "Home");
        //        }
        //    }
        //    var genres = await _genreService.GetAll();
        //    ViewBag.Genres = new SelectList(genres, "Id", "Name", User.GenreId);
        //    return View("~/Views/User/Edit.cshtml", User);
        //}

        //public async Task<IActionResult> DeleteUser(int id)
        //{
        //    var UserToDelete = await _UserService.GetById(id);
        //    var authorAssignToUser = await _authorUserService.GetByUserId(id);
        //    var articleHaveUser = await _articleService.GetByUserId(id);
        //    var shelfHaveUser = await _shelfService.GetByUserId(id);

        //    if (authorAssignToUser.Any())
        //    {
        //        TempData["Fail"] = "Delete User failed, still assigned to author!";
        //        return RedirectToAction("UserList", "Home");
        //    }
        //    if (articleHaveUser.Any())
        //    {
        //        TempData["Fail"] = "Delete User failed, still have article!";
        //        return RedirectToAction("UserList", "Home");
        //    }
        //    if (shelfHaveUser.Any())
        //    {
        //        TempData["Fail"] = "Delete User failed, still have shelf!";
        //        return RedirectToAction("UserList", "Home");
        //    }
        //    if (UserToDelete != null)
        //    {
        //        int result = await _UserService.Delete(id);
        //        if (result != 0)
        //        {
        //            if (!string.IsNullOrEmpty(UserToDelete.Image))
        //            {
        //                var pathUser = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\assets\images\User");
        //                var imagePath = Path.Combine(pathUser, UserToDelete.Image);
        //                if (System.IO.File.Exists(imagePath))
        //                {
        //                    System.IO.File.Delete(imagePath);
        //                }
        //            }
        //            TempData["Success"] = "Delete User success!";
        //        }
        //        else
        //        {
        //            TempData["Fail"] = "Delete User failed!";
        //        }
        //        return RedirectToAction("UserList", "Home");
        //    }
        //    return View("~/Views/Error/NotFound404.cshtml");
        //}
    }
}
