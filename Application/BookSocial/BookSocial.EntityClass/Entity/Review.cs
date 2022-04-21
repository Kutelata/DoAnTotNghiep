using BookSocial.EntityClass.Enum;

namespace BookSocial.EntityClass.Entity
{
    public class Review :BaseEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Star Star { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int BookId { get; set; }
        public int UserId { get; set; }
    }
}
