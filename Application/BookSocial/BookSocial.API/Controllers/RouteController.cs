using BookSocial.DataAccess.DataAccessClass;
using BookSocial.DataAccess.DataAccessInterface;
using BookSocial.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace BookSocial.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IUserRepository _iud;

        public RouteController(IUserRepository iud)
        {
            _iud = iud;
        }

        [HttpGet]
        public  async Task<IActionResult> GetUserSaveCookie(string account, string password)
        {
            try
            {
                var Data = await _iud.CheckLogin(account, password);
                return Ok(Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
