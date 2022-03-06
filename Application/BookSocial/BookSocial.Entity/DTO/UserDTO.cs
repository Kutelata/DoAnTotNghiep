using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSocial.Entity.DTO
{
    public class UserSaveCookie
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        [Required]
        public string Account { get; set; }
        [Required]
        public string Password { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Birthday { get; set; }
        public bool Gender { get; set; }
        public bool Status { get; set; }
        public string Role { get; set; }

        public UserSaveCookie(
            int Id, string UserName, string Phone, string Email, string Account, 
            string Password, string Image, string Address, string Description, 
            string Birthday, bool Gender, bool Status, string Role)
        {
            this.Id = Id;
            this.UserName = UserName;
            this.Phone = Phone;
            this.Email = Email;
            this.Account = Account;
            this.Password = Password;
            this.Image = Image;
            this.Address = Address;
            this.Description = Description;
            this.Birthday = Birthday;
            this.Gender = Gender;
            this.Status = Status;
            this.Role = Role;
        }
    }
}
