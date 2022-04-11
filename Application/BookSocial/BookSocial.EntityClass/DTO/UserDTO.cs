using BookSocial.EntityClass.Enum;

namespace BookSocial.EntityClass.DTO
{
    public class UserSaveCookie
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Birthday { get; set; }
        public int Gender { get; set; }
        public string Friend { get; set; }
        public int Status { get; set; }
        public int Role { get; set; }
    }

    public class UserLogin
    {
        public string Account { get; set; }
        public string Password { get; set; }
    }

    public class UserStatistic
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Account { get; set; }
        public string Image { get; set; }
        public Gender Gender { get; set; }
        public Status Status { get; set; }
        public int NumberOfFriends { get; set; }
        public int NumberBooksOnShelf { get; set; }
        public int NumberOfArticles { get; set; }
        public int NumberOfComments { get; set; }
    }
}
