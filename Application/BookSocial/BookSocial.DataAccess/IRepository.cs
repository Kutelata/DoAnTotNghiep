using BookSocial.Entity;

namespace BookSocial.DataAccess
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<int> Create(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(int id);
    }
}
