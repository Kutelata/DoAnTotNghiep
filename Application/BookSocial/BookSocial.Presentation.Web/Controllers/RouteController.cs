using BookSocial.EntityClass.DTO;
using BookSocial.Service.ServiceInterface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookSocial.Presentation.Web.Controllers
{
    public class RouteController : Controller
    {
        private readonly IUserService _userService;

        public RouteController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Login()
        {
            return View("~/Views/Login.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLogin userLogin)
        {
            if (userLogin.Account == null)
            {
                ModelState.AddModelError("Account", "Account is required!");
            }
            if (userLogin.Password == null)
            {
                ModelState.AddModelError("Password", "Password is required!");
            }
            if (ModelState.IsValid)
            {
                var data = await _userService.GetUserSaveCookie(userLogin);
                if (data != null)
                {
                    //create claims
                    List<Claim> claims = new()
                    {
                        new Claim("Id", data.Id.ToString()),
                        new Claim("UserName", data.UserName != null ? data.UserName.ToString() : ""),
                        new Claim("Phone", data.Phone != null ? data.Phone.ToString() : ""),
                        new Claim("Email", data.Email != null ? data.Email.ToString() : ""),
                        new Claim("Account", data.Account.ToString()),
                        new Claim("Password", data.Password.ToString()),
                        new Claim("Image", data.Image != null ? data.Image.ToString() : ""),
                        new Claim("Address", data.Address != null ? data.Address.ToString() : ""),
                        new Claim("Description", data.Description != null ? data.Description.ToString() : ""),
                        new Claim("Birthday", data.Birthday != null ? data.Birthday.ToString() : ""),
                        new Claim("Gender", data.Gender.ToString()),
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
                    ModelState.AddModelError(string.Empty, "Account or Password is not match!");
                }
            }
            return View("~/Views/Login.cshtml");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Route");
        }

        public IActionResult Register()
        {
            return View("~/Views/Register.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Register(EntityClass.Entity.User user)
        {
            var checkAccountUnique = await _userService.GetByAccount(user.Account);
            var checkEmailUnique = await _userService.GetByEmail(user.Email);
            if (checkAccountUnique != null)
            {
                ModelState.AddModelError("Account", "User Account must be unique");
            }
            if (checkEmailUnique != null)
            {
                ModelState.AddModelError("Email", "User Email must be unique");
            }
            if (ModelState.IsValid)
            {
                var result = await _userService.Create(user);
                if (result != 0)
                {
                    TempData["Success"] = "Register Account success!";
                    return RedirectToAction("Login", "Route");
                }
                else
                {
                    TempData["Fail"] = "Register Account failed!";
                }
            }
            return View("~/Views/Register.cshtml", user);
        }

        public IActionResult Error()
        {
            return View("~/Views/Error.cshtml");
        }
    }
}
