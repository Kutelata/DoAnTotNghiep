using BookSocial.EntityClass.Entity;
using BookSocial.Service.ServiceInterface;
using System.Net.Http.Json;

namespace BookSocial.Service.ServiceClass
{
    public class FriendService : ConnectAPI, IFriendService
    {
        public async Task<Friend> GetByUserAndUserFriendId(int userId, int userFriendId)
        {
            var response = await GetClient().GetAsync($"Friend/GetByUserAndUserFriendId?userId={userId}&userFriendId={userFriendId}");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<Friend>() : null;
            return data;
        }
    }
}
