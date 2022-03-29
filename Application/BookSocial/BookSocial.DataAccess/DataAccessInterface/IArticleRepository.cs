using BookSocial.EntityClass.Entity;

namespace BookSocial.DataAccess.DataAccessInterface
{
    public interface IArticleRepository: IRepository<Article>
    {
        Task<IEnumerable<Article>> GetByBookId(int bookId);
    }
}
