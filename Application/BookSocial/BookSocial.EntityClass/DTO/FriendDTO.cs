using BookSocial.EntityClass.Enum;

namespace BookSocial.EntityClass.DTO
{
    public class FriendListHome
    {
        public int UserFriendId { get; set; }
        public string UserFriendName { get; set; }
        public string Image { get; set; }
    }

    public class FriendList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public Gender Gender { get; set; }
        public AccountStatus Status { get; set; }
        public SingleBookCurrentlyReading SingleBookCurrentlyReading { get; set; }
    }
}
