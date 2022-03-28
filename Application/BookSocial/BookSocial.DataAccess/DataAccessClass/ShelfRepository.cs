using BookSocial.DataAccess.DataAccessInterface;
using BookSocial.EntityClass.Entity;

namespace BookSocial.DataAccess.DataAccessClass
{
    public class ShelfRepository : ConnectionStrings, IShelfRepository
    {
        public Task<int> Create(Shelf entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Shelf>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Shelf> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Shelf entity)
        {
            throw new NotImplementedException();
        }
    }
}
