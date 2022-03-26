using BookSocial.EntityClass.DTO;

namespace BookSocial.Service.ServiceInterface
{
    public interface IUserService
    {
        public Task<UserSaveCookie> GetUserSaveCookie(UserLogin userLogin);
    }
}