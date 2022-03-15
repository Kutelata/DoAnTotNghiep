using BookSocial.EntityClass.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSocial.EntityClass.Entity
{
    public class UserReview :BaseEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Review Review { get; set; }
        public DateTime Created_At { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
    }
}
