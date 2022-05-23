using BookSocial.EntityClass.Entity;

namespace BookSocial.Service.ServiceInterface
{
    public interface IFriendService
    {
        Task<Friend> GetByUserAndUserFriendId(int userId, int userFriendId);
        Task<int> DeleteByUserAndUserFriendId(int userId, int userFriendId);
        Task<double> GetTotalByUserIdAndUserFriendId(int userId, int userFriendId);
        Task<int> Create(Friend friend);
    }
}