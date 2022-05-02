using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;

namespace BookSocial.Service.ServiceInterface
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
        Task<IEnumerable<FriendList>> GetAllUser();
        Task<IEnumerable<UserStatistic>> GetUserStatistic();
        Task<IEnumerable<UserEmployeeStatistic>> GetUserEmployeeStatistic();
        Task<UserSaveCookie> GetUserSaveCookie(UserLogin userLogin);
        Task<AdminSaveCookie> GetAdminSaveCookie(UserLogin userLogin);
        Task<User> GetById(int id);
        Task<User> GetByAccount(string userAccount);
        Task<User> GetByEmail(string userEmail);
        Task<int> Create(User user);
        Task<int> Update(User user);
        Task<int> Delete(int userId);
    }
}