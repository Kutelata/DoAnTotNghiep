using BookSocial.DataAccess.DataAccessInterface;
using Microsoft.AspNetCore.Mvc;

namespace BookSocial.API.Controllers
{
    public class GenreController : BaseController
    {
        private readonly IGenreRepository _genreRepository;

        public GenreController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetGenreStatistic()
        {
            try
            {
                var data = await _genreRepository.GetGenreStatistic();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
