using BookSocial.EntityClass.Entity;

namespace BookSocial.Service.ServiceInterface
{
    public interface IArticleService
    {
        Task<IEnumerable<Article>> GetByBookId(int bookId);
    }
}
