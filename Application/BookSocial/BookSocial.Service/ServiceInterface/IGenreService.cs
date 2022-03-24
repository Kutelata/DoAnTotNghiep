using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;

namespace BookSocial.Service.ServiceInterface
{
    public interface IGenreService
    {
        public Task<IEnumerable<GenreStatistic>> GetGenreStatistic();
        public Task<Genre> GetById(int genreId);
        public Task<Genre> GetByName(string genreName);
        public Task<int> Create(Genre genre);
        public Task<int> Update(Genre genre);
        public Task<int> Delete(int genreId);
    }
}
