using BookSocial.EntityClass.DTO;
using BookSocial.Service.ServiceInterface;
using System.Net.Http.Json;

namespace BookSocial.Service.ServiceClass
{
    public class UserService : ConnectAPI, IUserService
    {
        public async Task<UserSaveCookie> GetUserSaveCookie(UserLogin userLogin)
        {
            var response = await GetClient()
                .GetAsync($"User/GetUserSaveCookie?account={userLogin.Account}&password={userLogin.Password}");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<UserSaveCookie>() : null;
            return data;
        }
    }
}