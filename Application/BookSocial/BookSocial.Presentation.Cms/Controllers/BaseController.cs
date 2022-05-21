using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.Cms.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}
