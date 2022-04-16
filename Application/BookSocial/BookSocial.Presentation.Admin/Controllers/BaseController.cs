using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.Admin.Controllers
{
    [Authorize(Policy = )]
    public class BaseController : Controller
    {
    }
}
