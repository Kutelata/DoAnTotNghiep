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
        [Display(Name = "Quản lý toàn bộ")]
        Admin = 1,
        [Display(Name = "Quản lý thư viện")]
        LibraryManager = 2,
        [Display(Name = "Quản lý người dùng")]
        UserManager = 3
    }
}
