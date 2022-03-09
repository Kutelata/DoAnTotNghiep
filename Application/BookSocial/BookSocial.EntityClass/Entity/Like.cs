using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSocial.EntityClass.Entity
{
    public class Like : BaseEntity
    {
        public int AuthorID { get; set; }
        public int ArticleId { get; set; }
        public int UserId { get; set; }
    }
}
