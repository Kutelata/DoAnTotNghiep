using AutoMapper;
using BookSocial.EntityClass;
using BookSocial.EntityClass.Enum;
using BookSocial.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// AddScoped HttpClient
builder.Services.AddSingleton(builder.Configuration.GetSection("ConnectAPI").Get<ConnectAPI>());

// AddScoped Service
RegisterService.Register(builder.Services);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Route/Login";
        options.AccessDeniedPath = "/Route/Unauthorize401";
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireClaim("Role", $"{(int)RoleEmployee.Admin}"));
    options.AddPolicy("Library Manager", policy => policy.RequireClaim("Role", $"{(int)RoleEmployee.LibraryManager}"));
    options.AddPolicy("User Manager", policy => policy.RequireClaim("Role", $"{(int)RoleEmployee.UserManager}"));
});

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
// Add IMappper
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    // Default
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    // Not Found
    endpoints.MapControllerRoute(
        name: "not found",
        pattern: "{*url}",
        defaults: new { controller = "Route", action = "NotFound404" });
});

app.Run();