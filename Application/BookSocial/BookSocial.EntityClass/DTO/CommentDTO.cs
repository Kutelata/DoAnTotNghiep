using BookSocial.EntityClass.Entity;

namespace BookSocial.EntityClass.DTO
{
    public class CommentStatistic
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
    }

    public class RecentActivityComment
    {
        public int UserCommentId { get; set; }
        public string UserCommentName { get; set; }
        public int UserReviewId { get; set; }
        public string UserReviewName { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public DateTime CommentCreatedAt { get; set; }
    }

    public class CommentInReview
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
