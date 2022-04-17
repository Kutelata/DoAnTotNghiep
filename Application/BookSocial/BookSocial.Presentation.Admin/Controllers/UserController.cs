using BookSocial.EntityClass.Enum;
using CsvHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace BookSocial.Presentation.Admin.Controllers
{
    public partial class HomeController
    {
        [Authorize(Policy = "User Manager")]
        public async Task<IActionResult> UserList(int page = 1, string search = null, string sort = "Id")
        {
            var allData = await _userService.GetUserStatistic();
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
                        case "Email": dataInPage = dataInPage.OrderBy(x => x.Email); break;
                        case "Account": dataInPage = dataInPage.OrderBy(x => x.Account); break;
                        case "Image": dataInPage = dataInPage.OrderBy(x => x.Image); break;
                        case "Gender": dataInPage = dataInPage.OrderBy(x => x.Gender); break;
                        case "Status": dataInPage = dataInPage.OrderBy(x => x.Status); break;
                        case "NumberOfFriends": dataInPage = dataInPage.OrderBy(x => x.NumberOfFriends); break;
                        case "NumberBooksOnShelf": dataInPage = dataInPage.OrderBy(x => x.NumberBooksOnShelf); break;
                        case "NumberOfArticles": dataInPage = dataInPage.OrderBy(x => x.NumberOfArticles); break;
                        case "NumberOfComments": dataInPage = dataInPage.OrderBy(x => x.NumberOfComments); break;
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
                        (data.Email != null && data.Email.Contains(search)) ||
                        (data.Account != null && data.Account.Contains(search)) ||
                        (data.Image != null && data.Image.Contains(search)) ||
                        data.Gender.ToString() == search ||
                        data.Status.ToString() == search ||
                        data.NumberOfFriends.ToString() == search ||
                        data.NumberBooksOnShelf.ToString() == search ||
                        data.NumberOfArticles.ToString() == search ||
                        data.NumberOfComments.ToString() == search);
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
            return View("~/Views/User/User/Index.cshtml", dataInPage);
        }

        [Authorize(Policy = "User Manager")]
        public async Task<IActionResult> ExportUserToCsv()
        {
            var data = await _userService.GetUserStatistic();

            using (var memoryStream = new MemoryStream())
            {
                using (var streamWriter = new StreamWriter(memoryStream))
                using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                {
                    csvWriter.WriteRecords(data);
                }
                return File(memoryStream.ToArray(), "text/csv", "UserReports.csv");
            }
        }

        [Authorize(Policy = "User Manager")]
        public async Task<IActionResult> DetailUser(int id)
        {
            var dataUser = await _userService.GetById(id);
            if (dataUser != null)
            {
                return View("~/Views/User/User/Detail.cshtml", dataUser);
            }
            return RedirectToAction("NotFound404", "Route");
        }

        [Authorize(Policy = "User Manager")]
        public async Task<IActionResult> ChangeStatus(int userId, Status userStatus)
        {
            var dataUser = await _userService.GetById(userId);
            if (dataUser != null)
            {
                dataUser.Status = userStatus;
                int result = await _userService.Update(dataUser);
                if (result != 0)
                {
                    TempData["Success"] = "Change status success!";
                }
                else
                {
                    TempData["Fail"] = "Change status failed!";
                }
                return View("~/Views/User/User/Detail.cshtml", dataUser);
            }
            return RedirectToAction("NotFound404", "Route");
        }

        [Authorize(Policy = "User Manager")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var userToDelete = await _userService.GetById(id);
            var shelfOfUser = await _shelfService.GetByUserId(id);
            var articleOfUser = await _articleService.GetByUserId(id);
            var commentOfUser = await _commentService.GetByUserId(id);

            if (shelfOfUser.Any())
            {
                TempData["Fail"] = "Delete User failed, still have shelf!";
                return RedirectToAction("UserList", "Home");
            }
            if (articleOfUser.Any())
            {
                TempData["Fail"] = "Delete User failed, still have article!";
                return RedirectToAction("UserList", "Home");
            }
            if (commentOfUser.Any())
            {
                TempData["Fail"] = "Delete User failed, still have comment!";
                return RedirectToAction("UserList", "Home");
            }
            if (userToDelete != null)
            {
                int result = await _userService.Delete(id);
                if (result != 0)
                {
                    if (!string.IsNullOrEmpty(userToDelete.Image))
                    {
                        var pathUser = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\assets\images\user");
                        var imagePath = Path.Combine(pathUser, userToDelete.Image);
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }
                    }
                    TempData["Success"] = "Delete User success!";
                }
                else
                {
                    TempData["Fail"] = "Delete User failed!";
                }
                return RedirectToAction("UserList", "Home");
            }
            return View("~/Views/Error/NotFound404.cshtml");
        }
    }
}
