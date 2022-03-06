using BookSocial.Presentation.User.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookSocial.Presentation.User.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
    }
}