using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;

namespace BookSocial.DataAccess.DataAccessInterface
{
    public interface IShelfRepository : IRepository<Shelf>
    {
        Task<IEnumerable<Shelf>> GetByBookId(int bookId);
        Task<IEnumerable<Shelf>> GetByUserId(int userId);
        Task<double> GetTotalByUserId(int userId);
        Task<double> GetTotalReadByUserId(int userId);
        Task<IEnumerable<ShelfListHome>> GetShelfListHomes(int userId);
        Task<Shelf> GetByBookAndUserId(int bookId, int userId);
        Task<IEnumerable<ShelfDetail>> GetByShelfDetail(int userId);
        Task<int> DeleteByBookAndUserId(int bookId, int userId);
    }
}
