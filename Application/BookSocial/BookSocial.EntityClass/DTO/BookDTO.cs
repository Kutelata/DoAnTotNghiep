using BookSocial.EntityClass.Entity;
using BookSocial.EntityClass.Enum;

namespace BookSocial.EntityClass.DTO
{
    public class BookStatistic
    {
        public int Id { get; set; }
        public string Isbn { get; set; }
        public string BookName { get; set; }
        public string Image { get; set; }
        public DateTime Published { get; set; }
        public string GenreName { get; set; }
        public int NumberOfAuthors { get; set; }
        public int NumberOfReviews { get; set; }
        public int NumberOfShelfs { get; set; }
    }

    public class BookListByAuthorId
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookImage { get; set; }
    }

    public class SingleBookCurrentlyReading
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookImage { get; set; }
    }

    public class SearchBook
    {
        public int UserId { get; set; }
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookImage { get; set; }
        public string BookDescription { get; set; }
        public ProgressReadOrigin UserClaimProgressRead { get; set; }
        public int NumberOfReviews { get; set; }
        public float AverageOfRating { get; set; }
        public IEnumerable<AuthorListByBookId> AuthorListByBookId { get; set; }
    }

    public class BookProfile
    {
        public int Id { get; set; }
        public string Isbn { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int? PageNumber { get; set; }
        public DateTime? Published { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public List<AuthorListByBookId> AuthorListByBookId { get; set; }
        public List<ReviewByBookId> ReviewByBookId { get; set; }
    }
}
