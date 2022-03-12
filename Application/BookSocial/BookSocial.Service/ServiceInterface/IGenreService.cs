using BookSocial.EntityClass.DTO;

namespace BookSocial.Service.ServiceInterface
{
    public interface IGenreService
    {
        public Task<GenreStatistic> GetGenreStatistic();
    }
}
