using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;

namespace BookSocial.DataAccess.DataAccessInterface
{
    public interface IGenreRepository : IRepository<Genre>
    {
        Task<IEnumerable<GenreStatistic>> GetGenreStatistic();
        Task<Genre> GetByName(string genreName);
    }
}
