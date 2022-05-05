using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.User.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}
