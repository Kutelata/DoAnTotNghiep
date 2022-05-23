using System.ComponentModel.DataAnnotations;

namespace BookSocial.EntityClass.Enum
{
    public enum AccountStatus
    {
        [Display(Name="Đã bị khóa")]
        Locked = 0,
        [Display(Name = "Đang hoạt động")]
        IsActive = 1
    }
}
