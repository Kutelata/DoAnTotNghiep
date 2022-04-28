using BookSocial.EntityClass.Entity;

namespace BookSocial.DataAccess.DataAccessInterface
{
    public interface IFriendRepository : IRepository<Friend>
    {
        Task<Friend> GetByUserAndUserFriendId(int userId, int userFriendId);
    }
}
