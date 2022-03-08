using BookSocial.DataAccess.DataAccessClass;
using BookSocial.DataAccess.DataAccessInterface;
using BookSocial.Entity;
using BookSocial.Entity.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BookSocial.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IUserRepository _iud;

        public RouteController(IUserRepository iud)
        {
            _iud = iud;
        }

        [HttpPost]
        public  async Task<IActionResult> GetUserSaveCookie(LoginViewModel lvm)
        {
            try
            {
                var Data = await _iud.GetUserSaveCookie(lvm);
                return Ok(Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
