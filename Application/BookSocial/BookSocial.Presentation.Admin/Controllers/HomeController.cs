﻿using BookSocial.Presentation.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookSocial.Presentation.Admin.Controllers
{
    public partial class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Dashboard/Index.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}