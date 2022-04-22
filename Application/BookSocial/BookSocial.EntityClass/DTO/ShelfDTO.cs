using BookSocial.EntityClass.Enum;

namespace BookSocial.EntityClass.DTO
{
    public class ShelfDetail
    {
        public int UserId { get; set; }
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookDescription { get; set; }
        public ProgressRead ProgressRead { get; set; }
    }
}
