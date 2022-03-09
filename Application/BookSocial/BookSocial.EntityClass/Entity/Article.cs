namespace BookSocial.EntityClass.Entity
{
    public class Article : BaseEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ParentId { get; set; }
        public int LevelId { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public int ProgressReadId { get; set; }
        public int Review { get; set; }
    }
}
