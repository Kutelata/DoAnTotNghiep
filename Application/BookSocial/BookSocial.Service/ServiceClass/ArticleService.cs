using System.Net.Http.Json;
using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;
using BookSocial.Service.ServiceInterface;

namespace BookSocial.Service.ServiceClass
{
    public class ArticleService : ConnectAPI, IArticleService
    {
        public async Task<IEnumerable<ArticleStatistic>> GetArticleStatistic()
        {
            var response = await GetClient().GetAsync($"Article/GetArticleStatistic");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<IEnumerable<ArticleStatistic>>() : null;
            return data;
        }

        public async Task<IEnumerable<Article>> GetByBookId(int bookId)
        {
            var response = await GetClient().GetAsync($"Article/GetByBookId?bookId={bookId}");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<IEnumerable<Article>>() : null;
            return data;
        }

        public async Task<Article> GetById(int articleId)
        {
            var response = await GetClient().GetAsync($"Article/GetById?id={articleId}");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<Article>() : null;
            return data;
        }

        public async Task<int> Delete(int articleId)
        {
            var response = await GetClient().DeleteAsync($"Article/Delete?id={articleId}");
            var data = response.IsSuccessStatusCode ? 1 : 0;
            return data;
        }

        public async Task<IEnumerable<Article>> GetByUserId(int userId)
        {
            var response = await GetClient().GetAsync($"Article/GetByUserId?userId={userId}");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<IEnumerable<Article>>() : null;
            return data;
        }
    }
}
