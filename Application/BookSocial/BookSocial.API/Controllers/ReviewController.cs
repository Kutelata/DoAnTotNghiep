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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var data = await _reviewRepository.GetAll();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetReviewStatistic()
        {
            try
            {
                var data = await _reviewRepository.GetReviewStatistic();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        
        [HttpGet]
        public async Task<IActionResult> GetReviewList()
        {
            try
            {
                var data = await _reviewRepository.GetReviewList();
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
                var data = await _reviewRepository.GetByBookId(bookId);
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
                var data = await _reviewRepository.GetByUserId(userId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var data = await _reviewRepository.GetById(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(Review Review)
        {
            try
            {
                int result = await _reviewRepository.Create(Review);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Review Review)
        {
            try
            {
                int result = await _reviewRepository.Update(Review);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
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
