namespace BookSocial.EntityClass.DTO
{
    public class HomeList
    {
        public List<ReviewList> ReviewList { get; set; }
        public List<ShelfListHome> ShelfListHome { get; set; }
        public List<RecentActivityComment> RecentActivityComment { get; set; }
        public List<FriendListHome> FriendListHomeSuggest { get; set; }
        public List<FriendListHome> FriendListHome { get; set; }
    }
}
