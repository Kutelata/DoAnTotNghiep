using BookSocial.Entity;
using BookSocial.Entity.DTO;

namespace BookSocial.DataAccess.DataAccessInterface
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<UserSaveCookie> GetUserSaveCookie(string account, string password);
    }
}
