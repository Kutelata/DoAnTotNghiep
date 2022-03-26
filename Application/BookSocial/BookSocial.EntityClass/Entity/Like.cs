namespace BookSocial.EntityClass.Entity
{
    public class Like : BaseEntity
    {
        public int AuthorId { get; set; }
        public int ArticleId { get; set; }
        public int CommentId { get; set; }
        public int UserId { get; set; }
    }
}
