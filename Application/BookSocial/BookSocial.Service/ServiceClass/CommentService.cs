﻿using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;
using BookSocial.Service.ServiceInterface;
using System.Net.Http.Json;

namespace BookSocial.Service.ServiceClass
{
    public class CommentService : ConnectApi, ICommentService
    {
        public async Task<int> Delete(int commentId)
        {
            var response = await GetClient().DeleteAsync($"Comment/Delete?id={commentId}");
            var data = response.IsSuccessStatusCode ? 1 : 0;
            return data;
        }

        public async Task<IEnumerable<Comment>> GetByReviewId(int reviewId)
        {
            var response = await GetClient().GetAsync($"Comment/GetByReviewId?reviewId={reviewId}");
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

        public async Task<IEnumerable<RecentActivityComment>> GetRecentActivityComment()
        {
            var response = await GetClient().GetAsync($"Comment/GetRecentActivityComment");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<IEnumerable<RecentActivityComment>>() : null;
            return data;
        }

        public async Task<int> Create(Comment comment)
        {
            var response = await GetClient().PostAsJsonAsync($"Comment/Create", comment);
            var data = response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<int>() : 0;
            return data;
        }

        public async Task<int> Update(Comment comment)
        {
            var response = await GetClient().PutAsJsonAsync($"Comment/Update", comment);
            var data = response.IsSuccessStatusCode ? 1 : 0;
            return data;
        }

        public async Task<double> GetTotalByUserId(int userId)
        {
            var response = await GetClient().GetAsync($"Comment/GetTotalByUserId?userId={userId}");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<double>() : 0;
            return data;
        }
    }
}
