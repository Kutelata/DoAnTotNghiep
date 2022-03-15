using BookSocial.EntityClass.DTO;

namespace BookSocial.Service.ServiceInterface
{
    public interface IGenreService
    {
        public Task<IEnumerable<GenreStatistic>> GetGenreStatistic();
    }
}
