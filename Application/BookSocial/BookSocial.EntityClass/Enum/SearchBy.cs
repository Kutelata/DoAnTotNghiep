using System.ComponentModel.DataAnnotations;

namespace BookSocial.EntityClass.Enum
{
    public enum SearchBy
    {
        [Display(Name = "Sách")]
        Book,
        [Display(Name = "Tác giả")]
        Author
    }
}
