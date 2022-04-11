using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;

namespace BookSocial.Service.ServiceInterface
{
    public interface IUserService
    {
        public Task<IEnumerable<UserStatistic>> GetUserStatistic();
        public Task<UserSaveCookie> GetUserSaveCookie(UserLogin userLogin);
        public Task<User> GetById(int id);
        public Task<int> Create(User user);
        public Task<int> Update(User user);
        public Task<int> Delete(int userId);
    }
}