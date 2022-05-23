using System.ComponentModel.DataAnnotations;

namespace BookSocial.EntityClass.Enum
{
    public enum Star
    {
        [Display(Name = "Không đánh giá")]
        Zero = 0,
        [Display(Name = "1 sao")]
        One = 1,
        [Display(Name = "2 sao")]
        Two = 2,
        [Display(Name = "3 sao")]
        Three = 3,
        [Display(Name = "4 sao")]
        Four = 4,
        [Display(Name = "5 sao")]
        Five = 5
    }
}
