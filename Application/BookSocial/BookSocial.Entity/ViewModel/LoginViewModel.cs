using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSocial.Entity.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string Account { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
