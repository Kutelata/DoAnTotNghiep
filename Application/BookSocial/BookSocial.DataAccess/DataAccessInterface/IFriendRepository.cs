using BookSocial.EntityClass.Entity;

namespace BookSocial.DataAccess.DataAccessInterface
{
    public interface IFriendRepository : IRepository<Friend>
    {
        Task<Friend> GetByUserAndUserFriendId(int userId, int userFriendId);
        Task<int> DeleteByUserAndUserFriendId(int userId, int userFriendId);
        Task<double> GetTotalByUserAndUserFriendId(int userId, int userFriendId);
    }
}
