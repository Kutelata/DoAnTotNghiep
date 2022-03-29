using BookSocial.EntityClass.Entity;

namespace BookSocial.DataAccess.DataAccessInterface
{
    public interface IAuthorBookRepository : IRepository<AuthorBook>
    {
        Task<IEnumerable<AuthorBook>> GetByBookId(int bookId);
        Task<int> Delete(int bookId, int authorId);
    }
}
