using BookSocial.EntityClass.Enum;

namespace BookSocial.EntityClass.Entity
{
    public class Article :BaseEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Star Star { get; set; }
        public DateTime Created_At { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
    }
}
