using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;

namespace BookSocial.Service.ServiceInterface
{
    public interface IBookService
    {
        public Task<IEnumerable<BookStatistic>> GetBookStatistic();
        public Task<IEnumerable<Book>> GetByGenreId(int genreId);
        public Task<Book> GetById(int id);
        public Task<Book> GetByIsbn(string isbn);
        public Task<int> Create(Book book);
        public Task<int> Update(Book book);
        public Task<int> Delete(int bookId);
    }
}
