using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSocial.EntityClass.Entity
{
    public class Like : BaseEntity
    {
        public int AuthorId { get; set; }
        public int UserBlogId { get; set; }
        public int UserReviewId { get; set; }
        public int UserCommentId { get; set; }
        public int UserId { get; set; }
    }
}
