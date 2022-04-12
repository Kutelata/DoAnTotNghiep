using BookSocial.DataAccess.DataAccessInterface;
using Microsoft.AspNetCore.Mvc;

namespace BookSocial.API.Controllers
{
    public class ShelfController : BaseController
    {
        private readonly IShelfRepository _shelfRepository;

        public ShelfController(IShelfRepository shelfRepository)
        {
            _shelfRepository = shelfRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetByBookId(int bookId)
        {
            try
            {
                var data = await _shelfRepository.GetByBookId(bookId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        
        [HttpGet]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            try
            {
                var data = await _shelfRepository.GetByUserId(userId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
