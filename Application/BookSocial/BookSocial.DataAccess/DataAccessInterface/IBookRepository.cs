using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;

namespace BookSocial.DataAccess.DataAccessInterface
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IEnumerable<BookStatistic>> GetBookStatistic();
        Task<IEnumerable<Book>> GetByGenreId(int genreId);
        Task<Book> GetByIsbn(string isbn);
    }
}
