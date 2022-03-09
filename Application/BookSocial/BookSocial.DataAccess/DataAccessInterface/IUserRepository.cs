using BookSocial.EntityClass.Entity;
using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.ViewModel;

namespace BookSocial.DataAccess.DataAccessInterface
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<UserSaveCookie> GetUserSaveCookie(LoginViewModel lvm);
    }
}
