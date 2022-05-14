using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;

namespace BookSocial.DataAccess.DataAccessInterface
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IEnumerable<BookStatistic>> GetBookStatistic();
        Task<IEnumerable<SearchBook>> GetSearchBook();
        Task<IEnumerable<Book>> GetByGenreId(int genreId);
        Task<IEnumerable<BookListByAuthorId>> GetBookListByAuthorId(int authorId);
        Task<Book> GetByIsbn(string isbn);
        Task<SingleBookCurrentlyReading> GetSingleBookCurrentlyReading(int userId);
    }
}
