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
            if (lvm.Account == null)
            {
                ModelState.AddModelError(String.Empty, "Account is required!");
            }
            if (lvm.Password == null)
            {
                ModelState.AddModelError(String.Empty, "Password is required!");
            }
            if (ModelState.IsValid)
            {
                var response = await _client.PostAsJsonAsync("Route/GetUserSaveCookie", lvm);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadFromJsonAsync<UserSaveCookie>();

                    //create claims
                    List<Claim> claims = new()
                    {
                        new Claim("Id", data.Id.ToString()),
                        new Claim("UserName", data.UserName.ToString()),
                        new Claim("Phone", data.Phone.ToString()),
                        new Claim("Email", data.Email.ToString()),
                        new Claim("Account", data.Account.ToString()),
                        new Claim("Password", data.Password.ToString()),
                        new Claim("Image", data.Image.ToString()),
                        new Claim("Address", data.Address.ToString()),
                        new Claim("Description", data.Description.ToString()),
                        new Claim("Birthday", data.Birthday.ToString()),
                        new Claim("Gender", data.Gender.ToString()),
                        new Claim("Friend", data.Friend.ToString()),
                        new Claim("Status", data.Status.ToString()),
                        new Claim("Role", data.Role.ToString()),
                    };

                    // create identity
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    // create principal
                    ClaimsPrincipal principal = new(claimsIdentity);

                    // sign-in
                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    ModelState.AddModelError(String.Empty, error);
                }
            }

            return View("~/Views/Login.cshtml");
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
