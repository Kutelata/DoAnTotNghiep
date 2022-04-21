namespace BookSocial.EntityClass.Entity
{
    public class Comment : BaseEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int ParentId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int ReviewId { get; set; }
        public int UserId { get; set; }
    }
}
