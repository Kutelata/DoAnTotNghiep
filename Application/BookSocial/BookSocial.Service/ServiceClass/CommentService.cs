using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;
using BookSocial.Service.ServiceInterface;
using System.Net.Http.Json;

namespace BookSocial.Service.ServiceClass
{
    public class CommentService : ConnectAPI, ICommentService
    {
        public async Task<int> Delete(int commentId)
        {
            var response = await GetClient().DeleteAsync($"Comment/Delete?id={commentId}");
            var data = response.IsSuccessStatusCode ? 1 : 0;
            return data;
        }

        public async Task<IEnumerable<Comment>> GetByArticleId(int articleId)
        {
            var response = await GetClient().GetAsync($"Comment/GetByArticleId?articleId={articleId}");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<IEnumerable<Comment>>() : null;
            return data;
        }

        public async Task<Comment> GetById(int commentId)
        {
            var response = await GetClient().GetAsync($"Comment/GetById?id={commentId}");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<Comment>() : null;
            return data;
        }

        public async Task<IEnumerable<Comment>> GetByParentId(int parentId)
        {
            var response = await GetClient().GetAsync($"Comment/GetByParentId?parentId={parentId}");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<IEnumerable<Comment>>() : null;
            return data;
        }

        public async Task<IEnumerable<Comment>> GetByUserId(int userId)
        {
            var response = await GetClient().GetAsync($"Comment/GetByUserId?userId={userId}");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<IEnumerable<Comment>>() : null;
            return data;
        }

        public async Task<IEnumerable<CommentStatistic>> GetCommentStatistic()
        {
            var response = await GetClient().GetAsync($"Comment/GetCommentStatistic");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<IEnumerable<CommentStatistic>>() : null;
            return data;
        }
    }
}
