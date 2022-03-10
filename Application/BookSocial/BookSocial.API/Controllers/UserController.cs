using BookSocial.DataAccess.DataAccessInterface;
using BookSocial.EntityClass.ViewModel;
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

        [HttpPost]
        public async Task<IActionResult> GetUserSaveCookie(LoginViewModel lvm)
        {
            try
            {
                var data = await _iur.GetUserSaveCookie(lvm);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
