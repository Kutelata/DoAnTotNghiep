﻿using BookSocial.EntityClass.DTO;
using BookSocial.Service.ServiceInterface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookSocial.Presentation.Cms.Controllers
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
                var data = await _userService.GetAdminSaveCookie(userLogin);
                if (data != null)
                {
                    //create claims
                    List<Claim> claims = new()
                    {
                        new Claim("Id", data.Id.ToString()),
                        new Claim("UserName", data.UserName != null ? data.UserName.ToString() : ""),
                        new Claim("Account", data.Account.ToString()),
                        new Claim("Password", data.Password.ToString()),
                        new Claim("Image", data.Image != null ? data.Image.ToString() : ""),
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
