namespace BookSocial.EntityClass.Entity
{
    public class Friend :BaseEntity
    {
        public int UserId { get; set; }
        public int UserFriendId { get; set; }
    }
}