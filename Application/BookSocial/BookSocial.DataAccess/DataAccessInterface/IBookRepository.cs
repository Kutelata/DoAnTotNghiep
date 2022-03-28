using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;

namespace BookSocial.DataAccess.DataAccessInterface
{
    public interface IBookRepository : IRepository<Book>
    {
        public Task<IEnumerable<BookStatistic>> GetBookStatistic();
        public Task<IEnumerable<Book>> GetByGenreId(int genreId);
        public Task<Book> GetByIsbn(string isbn);
    }
}
