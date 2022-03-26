using BookSocial.EntityClass.Entity;

namespace BookSocial.DataAccess.DataAccessInterface
{
    public interface IAuthorBookRepository : IRepository<AuthorBook>
    {
        Task<int> Delete(int bookId, int authorId);
    }
}
