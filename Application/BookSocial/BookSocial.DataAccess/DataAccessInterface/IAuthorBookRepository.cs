using BookSocial.EntityClass.Entity;

namespace BookSocial.DataAccess.DataAccessInterface
{
    public interface IAuthorBookRepository : IRepository<AuthorBook>
    {
        Task<IEnumerable<AuthorBook>> GetByBookId(int bookId);
        Task<IEnumerable<AuthorBook>> GetByAuthorId(int authorId);
        Task<AuthorBook> GetByAuthorBookId(int bookId, int authorId);
        Task<int> Delete(int bookId, int authorId);
    }
}
