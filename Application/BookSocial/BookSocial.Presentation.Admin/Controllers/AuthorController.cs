using BookSocial.EntityClass.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.Admin.Controllers
{
    public partial class HomeController
    {
        [Authorize(Policy = "Admin and Library Manager")]
        public async Task<IActionResult> AuthorList(int page = 1, string search = null, string sort = "Id")
        {
            var allData = await _authorService.GetAuthorStatistic();
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
                        case "AuthorName": dataInPage = dataInPage.OrderBy(x => x.AuthorName); break;
                        case "Image": dataInPage = dataInPage.OrderBy(x => x.Image); break;
                        case "Description": dataInPage = dataInPage.OrderBy(x => x.Description); break;
                        case "Birthday": dataInPage = dataInPage.OrderBy(x => x.Birthday); break;
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
                        (data.Id.ToString() == search) ||
                        (data.AuthorName != null && data.AuthorName.Contains(search)) ||
                        (data.Image != null && data.Image.Contains(search)) ||
                        (data.Description != null && data.Description.Contains(search)) ||
                        data.Birthday.ToString().Contains(search) ||
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
            ViewBag.CurrentSort = sort;
            return View("~/Views/Author/Index.cshtml", dataInPage);
        }

        [Authorize(Policy = "Admin and Library Manager")]
        public async Task<IActionResult> AuthorData(string search)
        {
            var data = await _authorService.GetAll();
            var handleData = data.Where(data => (data.Name != null && data.Name.Contains(search)));
            return Json(handleData);
        }

        [Authorize(Policy = "Admin and Library Manager")]
        public IActionResult CreateAuthor()
        {
            return View("~/Views/Author/Create.cshtml");
        }

        [Authorize(Policy = "Admin and Library Manager")]
        [HttpPost]
        public async Task<ActionResult> CreateAuthor(Author author, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    author.Image = $"{author.Id}_{author.Name}.jpg";
                }
                int result = await _authorService.Create(author);
                if (result != 0)
                {
                    if (Image != null && Image.Length > 0)
                    {
                        var pathBook = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\assets\images\author");
                        var imagePath = Path.Combine(pathBook, author.Image);
                        using (var stream = new FileStream(imagePath, FileMode.Create))
                        {
                            await Image.CopyToAsync(stream);
                        }
                    }
                    TempData["Success"] = "Create Author success!";
                }
                else
                {
                    TempData["Fail"] = "Create Author failed!";
                }
                return RedirectToAction("AuthorList", "Home");
            }
            return View("~/Views/Author/Create.cshtml", author);
        }

        [Authorize(Policy = "Admin and Library Manager")]
        public async Task<IActionResult> EditAuthor(int id)
        {
            var data = await _authorService.GetById(id);
            if (data != null)
            {
                return View("~/Views/Author/Edit.cshtml", data);
            }
            return RedirectToAction("NotFound404", "Route");
        }

        [Authorize(Policy = "Admin and Library Manager")]
        [HttpPost]
        public async Task<IActionResult> EditAuthor(Author author, IFormFile Image)
        {
            var currentAuthor = await _authorService.GetById(author.Id);
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    author.Image = $"{author.Id}_{author.Name}.jpg";
                }
                else
                {
                    author.Image = currentAuthor.Image;
                }
                int result = await _authorService.Update(author);
                if (result != 0)
                {
                    if (Image != null && Image.Length > 0)
                    {
                        var pathBook = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\assets\images\author");
                        var imagePath = Path.Combine(pathBook, author.Image);
                        using (var stream = new FileStream(imagePath, FileMode.Create))
                        {
                            await Image.CopyToAsync(stream);
                        }
                    }
                    TempData["Success"] = "Edit Author success!";
                }
                else
                {
                    TempData["Fail"] = "Edit Author failed!";
                }
                return RedirectToAction("AuthorList", "Home");
            }
            return View("~/Views/Author/Edit.cshtml", author);
        }

        [Authorize(Policy = "Admin and Library Manager")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var authorToDelete = await _authorService.GetById(id);
            var bookAssignToAuthor = await _authorBookService.GetByAuthorId(id);

            if (bookAssignToAuthor.Any())
            {
                TempData["Fail"] = "Delete Author failed, still assigned to book!";
                return RedirectToAction("AuthorList", "Home");
            }
            if (authorToDelete != null)
            {
                int result = await _authorService.Delete(id);
                if (result != 0)
                {
                    if (!string.IsNullOrEmpty(authorToDelete.Image))
                    {
                        var pathBook = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\assets\images\author");
                        var imagePath = Path.Combine(pathBook, authorToDelete.Image);
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }
                    }
                    TempData["Success"] = "Delete Author success!";
                }
                else
                {
                    TempData["Fail"] = "Delete Author failed!";
                }
                return RedirectToAction("AuthorList", "Home");
            }
            return View("~/Views/Error/NotFound404.cshtml");
        }
    }
}
