using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;

namespace BookSocial.DataAccess.DataAccessInterface
{
    public interface IReviewRepository: IRepository<Review>
    {
        Task<IEnumerable<ReviewStatistic>> GetReviewStatistic();
        Task<IEnumerable<ReviewList>> GetReviewList();
        Task<IEnumerable<Review>> GetByBookId(int bookId);
        Task<IEnumerable<Review>> GetByUserId(int userId);
    }
}
