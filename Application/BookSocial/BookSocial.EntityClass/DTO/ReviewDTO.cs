using BookSocial.EntityClass.Entity;
using BookSocial.EntityClass.Enum;

namespace BookSocial.EntityClass.DTO
{
    public class ReviewStatistic
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Star { get; set; }
        public DateTime CreatedAt { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int NumberOfComments { get; set; }
    }

    public class ReviewList
    {
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserImage { get; set; }
        public DateTime CreatedAt { get; set; }
        public ProgressRead UserProgressRead { get; set; }
        public string Text { get; set; }
        public Star Star { get; set; }
        public int BookId { get; set; }
        public string BookImage { get; set; }
        public string BookName { get; set; }
        public string BookDescription { get; set; }
        public ProgressReadOrigin UserClaimProgressRead { get; set; }
        public IEnumerable<AuthorListByBookId> AuthorListByBookId { get; set; }
    }

    public class ReviewByUserId
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Star Star { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int BookId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
