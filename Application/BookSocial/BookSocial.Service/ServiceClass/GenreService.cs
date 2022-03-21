using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;
using BookSocial.Service.ServiceInterface;
using System.Net.Http.Json;

namespace BookSocial.Service.ServiceClass
{
    public class GenreService : ConnectAPI, IGenreService
    {
        public async Task<int> Create(Genre genre)
        {
            var response = await GetClient().PostAsJsonAsync($"Genre/Create", genre);
            var data = response.IsSuccessStatusCode ? 1 : 0;
            return data;
        }

        public async Task<Genre> GetById(int genreId)
        {
            var response = await GetClient().GetAsync($"Genre/GetById?id={genreId}");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<Genre>() : null;
            return data;
        }

        public async Task<Genre> GetByName(string genreName)
        {
            var response = await GetClient().GetAsync($"Genre/GetByName?genreName={genreName}");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<Genre>() : null;
            return data;
        }

        public async Task<IEnumerable<GenreStatistic>> GetGenreStatistic()
        {
            var response = await GetClient().GetAsync($"Genre/GetGenreStatistic");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<IEnumerable<GenreStatistic>>() : null;
            return data;
        }

        public async Task<int> Update(Genre genre)
        {
            var response = await GetClient().PostAsJsonAsync($"Genre/Update", genre);
            var data = response.IsSuccessStatusCode ? 1 : 0;
            return data;
        }
    }
}
