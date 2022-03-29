using BookSocial.DataAccess.DataAccessInterface;
using BookSocial.EntityClass.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BookSocial.API.Controllers
{
    public class AuthorBookController : BaseController
    {
        private readonly IAuthorBookRepository _authorBookRepository;

        public AuthorBookController(IAuthorBookRepository authorBookRepository)
        {
            _authorBookRepository = authorBookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var data = await _authorBookRepository.GetAll();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetByBookId(int bookId)
        {
            try
            {
                var data = await _authorBookRepository.GetByBookId(bookId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(AuthorBook authorBook)
        {
            try
            {
                int result = await _authorBookRepository.Create(authorBook);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int bookId, int authorId)
        {
            try
            {
                int result = await _authorBookRepository.Delete(bookId, authorId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
