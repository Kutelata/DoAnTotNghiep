using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;
using BookSocial.Service.ServiceInterface;
using System.Net.Http.Json;

namespace BookSocial.Service.ServiceClass
{
    public class UserService : ConnectAPI, IUserService
    {
        public async Task<int> Create(User user)
        {
            var response = await GetClient().PostAsJsonAsync($"User/Create", user);
            var data = response.IsSuccessStatusCode ? 1 : 0;
            return data;
        }

        public async Task<int> Delete(int userId)
        {
            var response = await GetClient().DeleteAsync($"User/Delete?id={userId}");
            var data = response.IsSuccessStatusCode ? 1 : 0;
            return data;
        }

        public async Task<User> GetById(int id)
        {
            var response = await GetClient().GetAsync($"User/GetById?id={id}");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<User>() : null;
            return data;
        }

        public async Task<IEnumerable<UserEmployeeStatistic>> GetUserEmployeeStatistic()
        {
            var response = await GetClient().GetAsync($"User/GetUserEmployeeStatistic");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<IEnumerable<UserEmployeeStatistic>>() : null;
            return data;
        }

        public async Task<UserSaveCookie> GetUserSaveCookie(UserLogin userLogin)
        {
            var response = await GetClient()
                .GetAsync($"User/GetUserSaveCookie?account={userLogin.Account}&password={userLogin.Password}");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<UserSaveCookie>() : null;
            return data;
        }

        public async Task<IEnumerable<UserStatistic>> GetUserStatistic()
        {
            var response = await GetClient().GetAsync($"User/GetUserStatistic");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<IEnumerable<UserStatistic>>() : null;
            return data;
        }

        public async Task<int> Update(User user)
        {
            var response = await GetClient().PutAsJsonAsync($"User/Update", user);
            var data = response.IsSuccessStatusCode ? 1 : 0;
            return data;
        }
    }
}