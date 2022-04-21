using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;

namespace BookSocial.Service.ServiceInterface
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentStatistic>> GetCommentStatistic();
        Task<IEnumerable<Comment>> GetByReviewId(int articleId);
        Task<IEnumerable<Comment>> GetByUserId(int userId);
        Task<IEnumerable<Comment>> GetByParentId(int parentId);
        Task<Comment> GetById(int commentId);
        Task<int> Delete(int commentId);
    }
}
