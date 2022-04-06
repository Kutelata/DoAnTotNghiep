using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;

namespace BookSocial.DataAccess.DataAccessInterface
{
    public interface IAuthorRepository : IRepository<Author>
    {
        public Task<IEnumerable<AuthorStatistic>> GetAuthorStatistic();
    }
}
