using BookSocial.EntityClass.Enum;
using System.ComponentModel.DataAnnotations;

namespace BookSocial.EntityClass.DTO
{
    public class UserSaveCookie
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Birthday { get; set; }
        public Gender Gender { get; set; }
        public AccountStatus Status { get; set; }
        public Role Role { get; set; }
    }

    public class AdminSaveCookie
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public Gender Gender { get; set; }
        public AccountStatus Status { get; set; }
        public Role Role { get; set; }
    }

    public class UserLogin
    {
        public string Account { get; set; }
        public string Password { get; set; }
    }

    public class UserRegister
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên người dùng không được để trống")]
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Tài khoản không được để trống")]
        public string Account { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Nhập lại mật khẩu không được để trống")]
        [Compare("Password", ErrorMessage = "Nhập lại không trùng khớp")]
        public string ConfirmPassword { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime? Birthday { get; set; }
        public Gender Gender { get; set; }
        public AccountStatus Status { get; set; }
        public Role Role { get; set; }
    }

    public class UserStatistic
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Account { get; set; }
        public string Image { get; set; }
        public Gender Gender { get; set; }
        public AccountStatus Status { get; set; }
        public double NumberOfFriends { get; set; }
        public double NumberBooksOnShelf { get; set; }
        public double NumberOfReviews { get; set; }
        public double NumberOfComments { get; set; }
    }

    public class UserEmployeeStatistic
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public Gender Gender { get; set; }
        public AccountStatus Status { get; set; }
        public Role Role { get; set; }
    }

    public class CRUDEmployee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên người dùng không được để trống")]
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Tài khoản không được để trống")]
        public string Account { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime? Birthday { get; set; }
        public Gender Gender { get; set; }
        public AccountStatus Status { get; set; }
        public RoleEmployee Role { get; set; }
    }

    public class ChangePassword
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Mật khẩu cũ không được để trống")]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "Mật khẩu mới không được để trống")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Nhập lại mật khẩu mới không được để trống")]
        [Compare("NewPassword",ErrorMessage = "Nhập lại không trùng khớp")]
        public string ConfirmPassword { get; set; }
    }
}