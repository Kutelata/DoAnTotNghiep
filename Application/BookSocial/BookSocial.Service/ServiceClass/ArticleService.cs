using System.Net.Http.Json;
using BookSocial.EntityClass.Entity;
using BookSocial.Service.ServiceInterface;

namespace BookSocial.Service.ServiceClass
{
    public class ArticleService : ConnectAPI, IArticleService
    {
        public async Task<IEnumerable<Article>> GetByBookId(int bookId)
        {
            var response = await GetClient().GetAsync($"Article/GetByBookId?bookId={bookId}");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<IEnumerable<Article>>() : null;
            return data;
        }
    }
}
