using BookSocial.Entity.DTO;
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

        public async Task<IActionResult> Login(string account, string password)
        {
            var response = await _client.GetFromJsonAsync<UserSaveCookie>("api/Route?account=admin&password=admin123");

            // create claims
            List<Claim> claims = new List<Claim>
            {
                new Claim("Account", response!.Account),
                new Claim("Password", response.Password),
            };

            // create identity
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // create principal
            ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);

            // sign-in
            await HttpContext.SignInAsync(principal);

            return Json(response);
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
