namespace BookSocial.EntityClass.Entity
{
    public class Blog : BaseEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
    }
}
