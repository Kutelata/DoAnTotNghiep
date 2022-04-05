using BookSocial.EntityClass.Entity;

namespace BookSocial.Service.ServiceInterface
{
    public interface IAuthorBookService
    {
        Task<IEnumerable<AuthorBook>> GetByBookId(int bookId);
        Task<AuthorBook> GetByAuthorBookId(int bookId, int authorId);
        Task<int> Create(AuthorBook authorBook);
        Task<int> Delete(int bookId, int authorId);
    }
}
