namespace BookSocial.EntityClass.DTO
{
    public class CommentStatistic
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int ParentId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ArticleId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int NumberCommentReplies { get; set; }
    }
}
