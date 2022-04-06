namespace BookSocial.EntityClass.DTO
{
    public class AuthorStatistic
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public DateTime Birthday { get; set; }
        public int NumberOfBooks { get; set; }
    }
}
