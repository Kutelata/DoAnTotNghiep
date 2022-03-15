using BookSocial.EntityClass.DTO;
using BookSocial.Service.ServiceInterface;
using System.Net.Http.Json;

namespace BookSocial.Service.ServiceClass
{
    public class GenreService : ConnectAPI, IGenreService
    {
        public async Task<IEnumerable<GenreStatistic>> GetGenreStatistic()
        {
            var response = await GetClient()
                .GetAsync($"Genre/GetGenreStatistic");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<IEnumerable<GenreStatistic>>() : null;
            return data;
        }
    }
}
