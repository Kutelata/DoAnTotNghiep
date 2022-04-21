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
}
