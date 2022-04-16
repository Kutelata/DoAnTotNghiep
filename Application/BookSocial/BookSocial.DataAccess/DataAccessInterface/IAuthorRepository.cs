using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;

namespace BookSocial.DataAccess.DataAccessInterface
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<IEnumerable<AuthorStatistic>> GetAuthorStatistic();
    }
}
