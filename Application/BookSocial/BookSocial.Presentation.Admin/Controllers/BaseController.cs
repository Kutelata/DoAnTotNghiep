using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.Admin.Controllers
{
    [Authorize(Policy = "Admin")]
    public class BaseController : Controller
    {
    }
}
