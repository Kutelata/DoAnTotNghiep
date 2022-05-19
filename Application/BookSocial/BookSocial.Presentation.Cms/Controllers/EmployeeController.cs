using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;
using BookSocial.EntityClass.Enum;
using CsvHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace BookSocial.Presentation.Admin.Controllers
{
    public partial class HomeController
    {
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> EmployeeList(int page = 1, string search = null, string sort = "Id")
        {
            var allData = await _userService.GetUserEmployeeStatistic();
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
                        case "UserName": dataInPage = dataInPage.OrderBy(x => x.UserName); break;
                        case "Account": dataInPage = dataInPage.OrderBy(x => x.Account); break;
                        case "Image": dataInPage = dataInPage.OrderBy(x => x.Image); break;
                        case "Gender": dataInPage = dataInPage.OrderBy(x => x.Gender); break;
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
                        data.Gender.ToString() == search ||
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
            ViewBag.CurrentSort = sort;
            return View("~/Views/User/Admin/Index.cshtml", dataInPage);
        }

        [Authorize(Policy = "Admin")]
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

        [Authorize(Policy = "Admin")]
        public IActionResult CreateEmployee()
        {
            return View("~/Views/User/Admin/Create.cshtml");
        }

        [Authorize(Policy = "Admin")]
        [HttpPost]
        public async Task<ActionResult> CreateEmployee(CRUDEmployee createEmployee)
        {
            var checkAccountUnique = await _userService.GetByAccount(createEmployee.Account);
            if (checkAccountUnique != null)
            {
                ModelState.AddModelError("Account", "User account must be unique");
            }

            createEmployee.Image = "";
            createEmployee.Status = AccountStatus.IsActive;
            createEmployee.Password = "123456";

            if (ModelState.IsValid)
            {
                var user = _mapper.Map<User>(createEmployee);
                int result = await _userService.Create(user);
                if (result != 0)
                {
                    TempData["Success"] = "Create User success!";
                }
                else
                {
                    TempData["Fail"] = "Create User failed!";
                }
                return RedirectToAction("EmployeeList", "Home");
            }
            return View("~/Views/User/Admin/Create.cshtml", createEmployee);
        }

        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> EditEmployee(int id)
        {
            var data = await _userService.GetById(id);
            if (data != null)
            {
                var user = _mapper.Map<CRUDEmployee>(data);
                return View("~/Views/User/Admin/Edit.cshtml", user);
            }
            return RedirectToAction("NotFound404", "Route");
        }

        [Authorize(Policy = "Admin")]
        [HttpPost]
        public async Task<IActionResult> EditEmployee(CRUDEmployee editEmployee)
        {
            var currentUser = await _userService.GetById(editEmployee.Id);
            var checkAccountUnique = await _userService.GetByAccount(editEmployee.Account);
            if (checkAccountUnique != null && currentUser.Account != editEmployee.Account)
            {
                ModelState.AddModelError("Account", "Employee account must be unique");
            }

            editEmployee.Image = "";
            editEmployee.Password = "123456";

            if (ModelState.IsValid)
            {
                var user = _mapper.Map<User>(editEmployee);
                int result = await _userService.Update(user);
                if (result != 0)
                {
                    TempData["Success"] = "Edit Employee success!";
                }
                else
                {
                    TempData["Fail"] = "Edit Employee failed!";
                }
                return RedirectToAction("EmployeeList", "Home");
            }
            return View("~/Views/User/Admin/Edit.cshtml", editEmployee);
        }

        [Authorize(Policy = "Admin")]
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
            return RedirectToAction("NotFound404", "Route");
        }
    }
}
