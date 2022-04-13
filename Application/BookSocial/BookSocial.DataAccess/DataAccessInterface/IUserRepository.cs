using BookSocial.EntityClass.Entity;
using BookSocial.EntityClass.DTO;

namespace BookSocial.DataAccess.DataAccessInterface
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<IEnumerable<UserStatistic>> GetUserStatistic();
        public Task<IEnumerable<UserEmployeeStatistic>> GetUserEmployeeStatistic();
        public Task<UserSaveCookie> GetUserSaveCookie(string account, string password);
    }
}
