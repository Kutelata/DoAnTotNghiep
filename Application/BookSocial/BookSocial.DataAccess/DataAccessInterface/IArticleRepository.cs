using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;

namespace BookSocial.DataAccess.DataAccessInterface
{
    public interface IArticleRepository: IRepository<Article>
    {
        Task<IEnumerable<ArticleStatistic>> GetArticleStatistic();
        Task<IEnumerable<Article>> GetByBookId(int bookId);
        Task<IEnumerable<Article>> GetByUserId(int userId);
    }
}
