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

    public class BookProfile
    {
        public int MyProperty { get; set; }
    }
}
