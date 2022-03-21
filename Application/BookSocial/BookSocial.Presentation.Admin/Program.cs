using BookSocial.Presentation.Admin.Models;
using BookSocial.Service;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddServerSideBlazor();

// AddScoped HttpClient
builder.Services.AddSingleton(builder.Configuration.GetSection("ConnectAPI").Get<ConnectAPI>());
builder.Services.AddScoped<MessageAfterAction>();

// AddScoped Repository
RegisterService.Register(builder.Services);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Route/Login";
    });

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

    // Add hub
    endpoints.MapBlazorHub();
});

app.Run();
