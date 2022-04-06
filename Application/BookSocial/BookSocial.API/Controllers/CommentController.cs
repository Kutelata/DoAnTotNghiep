using BookSocial.DataAccess.DataAccessInterface;
using Microsoft.AspNetCore.Mvc;

namespace BookSocial.API.Controllers
{
    public class CommentController : BaseController
    {
        private readonly ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetByArticleId(int articleId)
        {
            try
            {
                var data = await _commentRepository.GetByArticleId(articleId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
