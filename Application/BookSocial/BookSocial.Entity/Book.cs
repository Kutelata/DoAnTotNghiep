using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSocial.Entity
{
    public class Book : BaseEntity
    {
        public int Id { get; set; }
        public int Isbn { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public int PageNumber { get; set; }
        public int Published { get; set; }
        public string? Language { get; set; }
        public int GenreId { get; set; }
    }
}
