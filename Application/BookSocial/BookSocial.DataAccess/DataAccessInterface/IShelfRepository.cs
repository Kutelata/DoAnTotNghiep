using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;

namespace BookSocial.DataAccess.DataAccessInterface
{
    public interface IShelfRepository : IRepository<Shelf>
    {
        Task<IEnumerable<Shelf>> GetByBookId(int bookId);
        Task<IEnumerable<Shelf>> GetByUserId(int userId);
        Task<IEnumerable<ShelfDetail>> GetByShelfDetail(int userId);
    }
}
