using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;

namespace BookSocial.Service.ServiceInterface
{
    public interface IArticleService
    {
        Task<IEnumerable<ArticleStatistic>> GetArticleStatistic();
        Task<IEnumerable<Article>> GetByBookId(int bookId);
        Task<IEnumerable<Article>> GetByUserId(int userId);
        Task<Article> GetById(int articleId);
        Task<int> Delete(int articleId);
    }
}
