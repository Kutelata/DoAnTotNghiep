using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;

namespace BookSocial.Service.ServiceInterface
{
    public interface IBookService
    {
        public Task<IEnumerable<BookStatistic>> GetBookStatistic();
        public Task<IEnumerable<Book>> GetByGenreId(int genreId);
    }
}
