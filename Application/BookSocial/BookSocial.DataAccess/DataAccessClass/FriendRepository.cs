using BookSocial.DataAccess.DataAccessInterface;
using BookSocial.EntityClass.Entity;

namespace BookSocial.DataAccess.DataAccessClass
{
    public class FriendRepository : ConnectionStrings, IFriendRepository
    {
        public Task<int> Create(Friend entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Friend>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Friend> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Friend entity)
        {
            throw new NotImplementedException();
        }
    }
}
