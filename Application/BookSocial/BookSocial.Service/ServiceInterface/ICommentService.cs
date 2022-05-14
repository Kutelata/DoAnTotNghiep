using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;

namespace BookSocial.Service.ServiceInterface
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentStatistic>> GetCommentStatistic();
        Task<IEnumerable<RecentActivityComment>> GetRecentActivityComment();
        Task<IEnumerable<Comment>> GetByReviewId(int reviewId);
        Task<IEnumerable<Comment>> GetByUserId(int userId);
        Task<Comment> GetById(int commentId);
        Task<int> Create(Comment comment);
        Task<int> Update(Comment comment);
        Task<int> Delete(int commentId);
    }
}
