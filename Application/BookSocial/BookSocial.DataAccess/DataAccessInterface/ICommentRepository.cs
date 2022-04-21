using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;

namespace BookSocial.DataAccess.DataAccessInterface
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<IEnumerable<CommentStatistic>> GetCommentStatistic();
        Task<IEnumerable<Comment>> GetByReviewId(int reviewId);
        Task<IEnumerable<Comment>> GetByUserId(int userId);
        Task<IEnumerable<Comment>> GetByParentId(int parentId);
    }
}
