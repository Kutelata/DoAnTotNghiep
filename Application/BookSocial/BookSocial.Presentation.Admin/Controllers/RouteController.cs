using BookSocial.Entity.DTO;
using BookSocial.Entity.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookSocial.Presentation.Admin.Controllers
{
    public class RouteController : Controller
    {
        private readonly HttpClient _client;

        public RouteController(HttpClient client)
        {
            _client = client;
        }

        public IActionResult Login()
        {
            return View("~/Views/Login.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            var response = await _client
                .GetAsync("Route/GetUserSaveCookie?account=" + lvm.Account + "&password=" + lvm.Password);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<UserSaveCookie>();
                //create claims
                List<Claim> claims = new List<Claim>
                {
                    new Claim("Account", data.Account),
                    new Claim("Password", data.Password),
                };

                // create identity
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // create principal
                ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);

                // sign-in
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login","Route");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        public IActionResult NotFound404()
        {
            ViewBag.ErrorName = "404";
            ViewBag.ErrorContent = "Sorry but we couldn't find this page !!!";
            return View("~/Views/Error.cshtml");
        }

        public IActionResult Unauthorize401()
        {
            ViewBag.ErrorName = "401";
            ViewBag.ErrorContent = "Sorry you don't have permission to access !!!";
            return View("~/Views/Error.cshtml");
        }
    }
}
