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
        public string BookImage { get; set; }
        public string BookDescription { get; set; }
        public ProgressRead ProgressRead { get; set; }
        public int NumberOfReviews { get; set; }
        public float AverageOfRating { get; set; }
        public IEnumerable<AuthorListByBookId> AuthorListByBookId { get; set; }
    }

    public class ShelfWithProgressOrigin
    {
        public ProgressReadOrigin ProgressReadOrigin { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
    }

    public class ShelfListHome
    {
        public int BookId { get; set; }
        public string BookImage { get; set; }
        public string BookName { get; set; }
        public ProgressRead ProgressRead { get; set; }
        public IEnumerable<AuthorListByBookId> AuthorListByBookId { get; set; }
    }
}