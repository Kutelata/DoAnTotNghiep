using BookSocial.DataAccess.DataAccessInterface;
using BookSocial.EntityClass.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BookSocial.API.Controllers
{
    public class ReviewController : BaseController
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview(Review review)
        {
            try
            {
                int result = await _reviewRepository.Create(review);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReview(Review review)
        {
            try
            {
                int result = await _reviewRepository.Update(review);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteReview(int id)
        {
            try
            {
                int result = await _reviewRepository.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
