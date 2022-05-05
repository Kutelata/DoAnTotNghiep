using BookSocial.DataAccess.DataAccessInterface;
using BookSocial.EntityClass.Entity;
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

        [HttpPost]
        public async Task<IActionResult> Create(Friend friend)
        {
            try
            {
                int result = await _friendRepository.Create(friend);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteByUserAndUserFriendId(int userId, int userFriendId)
        {
            try
            {
                int result = await _friendRepository.DeleteByUserAndUserFriendId(userId, userFriendId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
