using BookSocial.EntityClass.Enum;

namespace BookSocial.EntityClass.Entity
{
    public class Shelf : BaseEntity
    {
        public int Page { get; set; }
        public ProgressRead ProgressRead { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
    }
}
