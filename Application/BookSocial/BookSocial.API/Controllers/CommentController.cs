﻿using BookSocial.DataAccess.DataAccessInterface;
using BookSocial.EntityClass.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Api.Controllers
{
    public class CommentController : BaseController
    {
        private readonly ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCommentStatistic()
        {
            try
            {
                var data = await _commentRepository.GetCommentStatistic();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetTotalByUserId(int userId)
        {
            try
            {
                var data = await _commentRepository.GetTotalByUserId(userId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetRecentActivityComment()
        {
            try
            {
                var data = await _commentRepository.GetRecentActivityComment();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetByReviewId(int reviewId)
        {
            try
            {
                var data = await _commentRepository.GetByReviewId(reviewId);
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
                var data = await _commentRepository.GetByUserId(userId);
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
                var data = await _commentRepository.GetById(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(Comment comment)
        {
            try
            {
                int result = await _commentRepository.Create(comment);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Comment comment)
        {
            try
            {
                int result = await _commentRepository.Update(comment);
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
                int result = await _commentRepository.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
