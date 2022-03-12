using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.ViewModel;

namespace BookSocial.Service.ServiceInterface
{
    public interface IUserService
    {
        public Task<UserSaveCookie> GetUserSaveCookie(LoginViewModel lvm);
    }
}