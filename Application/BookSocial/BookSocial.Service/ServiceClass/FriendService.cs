using BookSocial.EntityClass.Entity;
using BookSocial.Service.ServiceInterface;
using System.Net.Http.Json;

namespace BookSocial.Service.ServiceClass
{
    public class FriendService : ConnectAPI, IFriendService
    {
        public async Task<int> Create(Friend friend)
        {
            var response = await GetClient()
                .PostAsJsonAsync($"Friend/Create", friend);
            var data = response.IsSuccessStatusCode ? 1 : 0;
            return data;
        }

        public async Task<int> DeleteByUserAndUserFriendId(int userId, int userFriendId)
        {
            var response = await GetClient()
                .DeleteAsync($"Friend/DeleteByUserAndUserFriendId?userId={userId}&userFriendId={userFriendId}");
            var data = response.IsSuccessStatusCode ? 1 : 0;
            return data;
        }

        public async Task<Friend> GetByUserAndUserFriendId(int userId, int userFriendId)
        {
            var response = await GetClient().GetAsync($"Friend/GetByUserAndUserFriendId?userId={userId}&userFriendId={userFriendId}");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<Friend>() : null;
            return data;
        }

        public async Task<double> GetTotalByUserIdAndUserFriendId(int userId, int userFriendId)
        {
            var response = await GetClient().GetAsync($"Friend/GetTotalByUserAndUserFriendId?userId={userId}&userFriendId={userFriendId}");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<double>() : 0;
            return data;
        }
    }
}
