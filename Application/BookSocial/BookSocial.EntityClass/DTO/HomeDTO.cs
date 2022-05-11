namespace BookSocial.EntityClass.DTO
{
    public class HomeList
    {
        public List<ReviewList> ReviewList { get; set; }
        public List<ShelfListHome> ShelfListHome { get; set; }
        public List<RecentActivityComment> RecentActivityComment { get; set; }
    }
}
