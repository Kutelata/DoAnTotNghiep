using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSocial.EntityClass.Entity
{
    public class UserComment : BaseEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int UserReviewId { get; set; }
        public int UserBlogId { get; set; }
        public int ParentId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
    }
}
