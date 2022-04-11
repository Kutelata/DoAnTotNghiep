using BookSocial.EntityClass.Entity;

namespace BookSocial.Service.ServiceInterface
{
    public interface IShelfService
    {
        Task<IEnumerable<Shelf>> GetByBookId(int bookId);
        Task<IEnumerable<Shelf>> GetByUserId(int userId);
    }
}
