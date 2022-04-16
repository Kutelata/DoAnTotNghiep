using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;

namespace BookSocial.Service.ServiceInterface
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreStatistic>> GetGenreStatistic();
        Task<IEnumerable<Genre>> GetAll();
        Task<Genre> GetById(int genreId);
        Task<Genre> GetByName(string genreName);
        Task<int> Create(Genre genre);
        Task<int> Update(Genre genre);
        Task<int> Delete(int genreId);
    }
}
