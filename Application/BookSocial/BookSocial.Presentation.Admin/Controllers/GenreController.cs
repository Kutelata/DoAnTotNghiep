using BookSocial.EntityClass.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.Admin.Controllers
{
    public partial class HomeController
    {
        [Authorize(Policy = "Admin and Library Manager")]
        public async Task<IActionResult> GenreList(int page = 1, string search = null, string sort = "Id")
        {
            var allData = await _genreService.GetGenreStatistic();
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
                        (data.Id.ToString() == search) ||
                        (data.Name != null && data.Name.ToLower().Contains(search)) ||
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
            return View("~/Views/Genre/Index.cshtml", dataInPage);
        }

        [Authorize(Policy = "Admin and Library Manager")]
        public IActionResult CreateGenre()
        {
            return View("~/Views/Genre/Create.cshtml");
        }

        [Authorize(Policy = "Admin and Library Manager")]
        [HttpPost]
        public async Task<ActionResult> CreateGenre(Genre genre)
        {
            var checkNameUnique = await _genreService.GetByName(genre.Name);
            if (checkNameUnique != null)
            {
                ModelState.AddModelError("Name", "Genre Name must be unique");
            }
            if (ModelState.IsValid)
            {
                int result = await _genreService.Create(genre);
                if (result != 0)
                {
                    TempData["Success"] = "Create genre success!";
                }
                else
                {
                    TempData["Fail"] = "Create genre failed!";
                }
                return RedirectToAction("GenreList", "Home");
            }
            return View("~/Views/Genre/Create.cshtml", genre);

        }

        [Authorize(Policy = "Admin and Library Manager")]
        public async Task<IActionResult> EditGenre(int id)
        {
            var data = await _genreService.GetById(id);
            if (data != null)
            {
                return View("~/Views/Genre/Edit.cshtml", data);
            }
            return RedirectToAction("NotFound404", "Route");
        }

        [Authorize(Policy = "Admin and Library Manager")]
        [HttpPost]
        public async Task<IActionResult> EditGenre(Genre genre)
        {
            var currentGenre = await _genreService.GetById(genre.Id);
            var checkNameUnique = await _genreService.GetByName(genre.Name);
            if (checkNameUnique != null && checkNameUnique.Name != currentGenre.Name)
            {
                ModelState.AddModelError("Name", "Genre Name must be unique");
            }
            if (ModelState.IsValid)
            {
                int result = await _genreService.Update(genre);
                if (result != 0)
                {
                    TempData["Success"] = "Update genre success!";
                }
                else
                {
                    TempData["Fail"] = "Update genre failed!";
                }
                return RedirectToAction("GenreList", "Home");
            }
            return View("~/Views/Genre/Edit.cshtml", genre);
        }

        [Authorize(Policy = "Admin and Library Manager")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var data = await _genreService.GetById(id);
            if (data != null)
            {
                var checkBookExist = await _bookService.GetByGenreId(id);
                if (!checkBookExist.Any())
                {
                    int result = await _genreService.Delete(id);
                    if (result != 0)
                    {
                        TempData["Success"] = "Delete genre success!";
                    }
                    else
                    {
                        TempData["Fail"] = "Delete genre failed!";
                    }
                }
                else
                {
                    TempData["Fail"] = "Delete genre failed, still books left!";
                }
                return RedirectToAction("GenreList", "Home");
            }
            return RedirectToAction("NotFound404", "Route");
        }
    }
}
