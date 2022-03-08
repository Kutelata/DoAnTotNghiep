using BookSocial.Entity;
using BookSocial.Entity.DTO;
using BookSocial.Entity.ViewModel;

namespace BookSocial.DataAccess.DataAccessInterface
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<UserSaveCookie> GetUserSaveCookie(LoginViewModel lvm);
    }
}
