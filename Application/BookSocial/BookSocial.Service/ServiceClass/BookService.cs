using BookSocial.EntityClass.Entity;
using BookSocial.Service.ServiceInterface;
using System.Net.Http.Json;

namespace BookSocial.Service.ServiceClass
{
    public class BookService : ConnectAPI, IBookService
    {
        public async Task<IEnumerable<Book>> GetByGenreId(int genreId)
        {
            var response = await GetClient().GetAsync($"Book/GetByGenreId?genreId={genreId}");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<IEnumerable<Book>>() : null;
            return data;
        }
    }
}
