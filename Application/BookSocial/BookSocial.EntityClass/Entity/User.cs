using BookSocial.EntityClass.Enum;
using System.ComponentModel.DataAnnotations;

namespace BookSocial.EntityClass.Entity
{
    public class User : BaseEntity
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
        public string Image { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime? Birthday { get; set; }
        public Gender Gender { get; set; }
        public AccountStatus Status { get; set; }
        public Role Role { get; set; }
    }
}
