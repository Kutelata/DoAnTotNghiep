using System.ComponentModel.DataAnnotations;

namespace BookSocial.EntityClass.Enum
{
    public enum Role
    {
        [Display(Name = "Người dùng")]
        User = 0,
        [Display(Name = "Quản lý toàn bộ")]
        Admin = 1,
        [Display(Name = "Quản lý thư viện")]
        LibraryManager = 2,
        [Display(Name = "Quản lý người dùng")]
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
