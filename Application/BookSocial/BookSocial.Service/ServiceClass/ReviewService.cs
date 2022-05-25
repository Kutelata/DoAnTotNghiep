using System.Net.Http.Json;
using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;
using BookSocial.Service.ServiceInterface;

namespace BookSocial.Service.ServiceClass
{
    public class ReviewService : ConnectAPI, IReviewService
    {
        public async Task<IEnumerable<ReviewStatistic>> GetReviewStatistic()
        {
            var response = await GetClient().GetAsync($"Review/GetReviewStatistic");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<IEnumerable<ReviewStatistic>>() : null;
            return data;
        }

        public async Task<IEnumerable<Review>> GetByBookId(int bookId)
        {
            var response = await GetClient().GetAsync($"Review/GetByBookId?bookId={bookId}");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<IEnumerable<Review>>() : null;
            return data;
        }

        public async Task<Review> GetById(int reviewId)
        {
            var response = await GetClient().GetAsync($"Review/GetById?id={reviewId}");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<Review>() : null;
            return data;
        }

        public async Task<int> Create(Review review)
        {
            var response = await GetClient().PostAsJsonAsync($"Review/Create", review);
            var data = response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<int>() : 0;
            return data;
        }

        public async Task<int> Delete(int reviewId)
        {
            var response = await GetClient().DeleteAsync($"Review/Delete?id={reviewId}");
            var data = response.IsSuccessStatusCode ? 1 : 0;
            return data;
        }

        public async Task<IEnumerable<Review>> GetByUserId(int userId)
        {
            var response = await GetClient().GetAsync($"Review/GetByUserId?userId={userId}");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<IEnumerable<Review>>() : null;
            return data;
        }

        public async Task<IEnumerable<ReviewList>> GetReviewList()
        {
            var response = await GetClient().GetAsync($"Review/GetReviewList");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<IEnumerable<ReviewList>>() : null;
            return data;
        }

        public async Task<double> GetTotalByUserId(int userId)
        {
            var response = await GetClient().GetAsync($"Review/GetTotalByUserId?userId={userId}");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<double>() : 0;
            return data;
        }
    }
}
