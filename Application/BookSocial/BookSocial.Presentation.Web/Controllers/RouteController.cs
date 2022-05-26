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
                ModelState.AddModelError("Account", "Tài khoản không được để trống!");
            }
            if (userLogin.Password == null)
            {
                ModelState.AddModelError("Password", "Mật khẩu không được để trống!");
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
                    ModelState.AddModelError(string.Empty, "Tài khoản hoặc mật khẩu không khớp!");
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
                ModelState.AddModelError("Account", "Tài khoản đã tồn tại");
            }
            if (checkEmailUnique != null)
            {
                ModelState.AddModelError("Email", "Địa chỉ email đã tồn tại");
            }
            if (ModelState.IsValid)
            {
                var result = await _userService.Create(user);
                if (result != 0)
                {
                    TempData["Success"] = "Đăng ký tài khoản thành công!";
                    return RedirectToAction("Login", "Route");
                }
                else
                {
                    TempData["Fail"] = "Đăng ký tài khoản thất bại!";
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
