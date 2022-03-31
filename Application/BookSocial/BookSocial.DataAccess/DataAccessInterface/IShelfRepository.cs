using BookSocial.EntityClass.Entity;

namespace BookSocial.DataAccess.DataAccessInterface
{
    public interface IShelfRepository : IRepository<Shelf>
    {
        Task<IEnumerable<Shelf>> GetByBookId(int bookId);
    }
}
