using System.Net.Http.Json;
using BookSocial.EntityClass.Entity;
using BookSocial.Service.ServiceInterface;

namespace BookSocial.Service.ServiceClass
{
    public class ShelfService : ConnectAPI, IShelfService
    {
        public async Task<IEnumerable<Shelf>> GetByBookId(int bookId)
        {
            var response = await GetClient().GetAsync($"Shelf/GetByBookId?bookId={bookId}");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<IEnumerable<Shelf>>() : null;
            return data;
        }

        public async Task<IEnumerable<Shelf>> GetByUserId(int userId)
        {
            var response = await GetClient().GetAsync($"Shelf/GetByUserId?userId={userId}");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<IEnumerable<Shelf>>() : null;
            return data;
        }
    }
}
