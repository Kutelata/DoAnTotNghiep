using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.ViewModel;
using BookSocial.Service.ServiceInterface;
using System.Net.Http.Json;

namespace BookSocial.Service.ServiceClass
{
    public class UserService : IUserService
    {
        private readonly HttpClient _client;

        public UserService(HttpClient client)
        {
            _client = client;
        }

        public async Task<UserSaveCookie> GetUserSaveCookie(LoginViewModel lvm)
        {
            var response = await _client.PostAsJsonAsync("Route/GetUserSaveCookie", lvm);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var data = await response.Content.ReadFromJsonAsync<UserSaveCookie>();
            return data;
        }
    }
}
