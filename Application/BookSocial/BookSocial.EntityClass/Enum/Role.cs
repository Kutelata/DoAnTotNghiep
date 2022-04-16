using System.ComponentModel.DataAnnotations;

namespace BookSocial.EntityClass.Enum
{
    public enum Role
    {
        [Display(Name = "User")]
        User = 0,
        [Display(Name = "Admin")]
        Admin = 1,
        [Display(Name = "Library Manager")]
        LibraryManager = 2,
        [Display(Name = "User Manager")]
        UserManager = 3
    }

    public enum RoleEmployee
    {
        [Display(Name = "Admin")]
        Admin = 1,
        [Display(Name = "Library Manager")]
        LibraryManager = 2,
        [Display(Name = "User Manager")]
        UserManager = 3
    }
}
