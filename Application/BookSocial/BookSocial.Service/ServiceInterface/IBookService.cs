using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;

namespace BookSocial.Service.ServiceInterface
{
    public interface IBookService
    {
        Task<IEnumerable<BookStatistic>> GetBookStatistic();
        Task<IEnumerable<Book>> GetByGenreId(int genreId);
        Task<Book> GetById(int id);
        Task<Book> GetByIsbn(string isbn);
        Task<int> Create(Book book);
        Task<int> Update(Book book);
        Task<int> Delete(int bookId);
    }
}
