using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;

namespace BookSocial.Service.ServiceInterface
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewStatistic>> GetReviewStatistic();
        Task<IEnumerable<ReviewList>> GetReviewList();
        Task<IEnumerable<Review>> GetByBookId(int bookId);
        Task<IEnumerable<Review>> GetByUserId(int userId);
        Task<double> GetTotalByUserId(int userId);
        Task<Review> GetById(int reviewId);
        Task<int> Delete(int reviewId);
    }
}
