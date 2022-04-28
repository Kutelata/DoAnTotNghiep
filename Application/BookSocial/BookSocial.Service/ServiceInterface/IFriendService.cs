using BookSocial.EntityClass.Entity;

namespace BookSocial.Service.ServiceInterface
{
    public interface IFriendService
    {
        Task<Friend> GetByUserAndUserFriendId(int userId, int userFriendId);
    }
}