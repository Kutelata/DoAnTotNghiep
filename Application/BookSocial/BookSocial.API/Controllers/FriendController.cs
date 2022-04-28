using BookSocial.DataAccess.DataAccessInterface;
using Microsoft.AspNetCore.Mvc;

namespace BookSocial.API.Controllers
{
    public class FriendController : BaseController
    {
        private readonly IFriendRepository _friendRepository;

        public FriendController(IFriendRepository friendRepository)
        {
            _friendRepository = friendRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetByUserAndUserFriendId(int userId, int userFriendId)
        {
            try
            {
                var data = await _friendRepository.GetByUserAndUserFriendId(userId, userFriendId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
