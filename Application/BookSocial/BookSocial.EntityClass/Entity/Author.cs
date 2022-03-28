using System.ComponentModel.DataAnnotations;

namespace BookSocial.EntityClass.Entity
{
    public class Author : BaseEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Author Name is required")]
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public DateTime? Birthday { get; set; }
    }
}
