using System.ComponentModel.DataAnnotations;

namespace BookSocial.EntityClass.Enum
{
    public enum Status
    {
        [Display(Name="Locked")]
        Locked = 0,
        [Display(Name = "Is Not Active")]
        IsNotActive = 1,
        [Display(Name = "Is Active")]
        IsActive = 2
    }
}
