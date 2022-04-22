using BookSocial.EntityClass.Entity;
using BookSocial.EntityClass.DTO;

namespace BookSocial.DataAccess.DataAccessInterface
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<UserStatistic>> GetUserStatistic();
        Task<IEnumerable<UserEmployeeStatistic>> GetUserEmployeeStatistic();
        Task<AdminSaveCookie> GetAdminSaveCookie(string account, string password);
        Task<UserSaveCookie> GetUserSaveCookie(string account, string password);
        Task<User> GetByAccount(string userAccount);
        Task<User> GetByEmail(string userEmail);
    }
}
