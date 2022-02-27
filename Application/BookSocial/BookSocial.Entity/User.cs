using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSocial.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Birthday { get; set; }
        public bool Gender { get; set; }
        public string Friend { get; set; }
        public int Role_Id { get; set; }
    }
}
