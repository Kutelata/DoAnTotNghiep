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
        public int Gender { get; set; }
        public string Friend { get; set; }
        public int Status { get; set; }
        public int Role { get; set; }
    }

    public class AdminSaveCookie
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public int Gender { get; set; }
        public int Status { get; set; }
        public int Role { get; set; }
    }

    public class UserLogin
    {
        public string Account { get; set; }
        public string Password { get; set; }
    }

    public class UserRegister
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "User Name is required")]
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Account is required")]
        public string Account { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime? Birthday { get; set; }
        public Gender Gender { get; set; }
        public Status Status { get; set; }
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
        public Status Status { get; set; }
        public int NumberOfFriends { get; set; }
        public int NumberBooksOnShelf { get; set; }
        public int NumberOfReviews { get; set; }
        public int NumberOfComments { get; set; }
    }

    public class UserEmployeeStatistic
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public Gender Gender { get; set; }
        public Status Status { get; set; }
        public Role Role { get; set; }
    }

    public class CRUDEmployee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "User Name is required")]
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Account is required")]
        public string Account { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime? Birthday { get; set; }
        public Gender Gender { get; set; }
        public Status Status { get; set; }
        public RoleEmployee Role { get; set; }
    }

    public class ChangePassword
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Old Password is required")]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "New Password is required")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("NewPassword")]
        public string ConfirmPassword { get; set; }
    }
}
