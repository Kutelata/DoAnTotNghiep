using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;

namespace BookSocial.DataAccess.DataAccessInterface
{
    public interface IGenreRepository : IRepository<Genre>
    {
        public Task<IEnumerable<GenreStatistic>> GetGenreStatistic();
        public Task<Genre> GetByName(string genreName);
    }
}
