using System.ComponentModel.DataAnnotations;

namespace BookSocial.EntityClass.Enum
{
    public enum AccountStatus
    {
        [Display(Name="Locked")]
        Locked = 0,
        [Display(Name = "Is Active")]
        IsActive = 1
    }
}
