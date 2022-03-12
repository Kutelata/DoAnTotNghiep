using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.ViewModel;
using BookSocial.Service.ServiceInterface;
using System.Net.Http.Json;

namespace BookSocial.Service.ServiceClass
{
    public class UserService : ConnectAPI, IUserService
    {
        public async Task<UserSaveCookie> GetUserSaveCookie(LoginViewModel lvm)
        {
            var response = await GetClient()
                .GetAsync($"User/GetUserSaveCookie?account={lvm.Account}&password={lvm.Password}");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<UserSaveCookie>() : null;
            return data;
        }
    }
}