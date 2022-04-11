using BookSocial.EntityClass.Enum;
using System.ComponentModel.DataAnnotations;

namespace BookSocial.EntityClass.Entity
{
    public class User : BaseEntity
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
        public string Friend { get; set; }
        public Status Status { get; set; }
        public Role Role { get; set; }
    }
}
