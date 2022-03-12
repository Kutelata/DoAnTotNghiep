using BookSocial.DataAccess.DataAccessInterface;
using Microsoft.AspNetCore.Mvc;

namespace BookSocial.API.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserRepository _iur;

        public UserController(IUserRepository iur)
        {
            _iur = iur;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserSaveCookie(string account, string password)
        {
            try
            {
                var data = await _iur.GetUserSaveCookie(account, password);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
