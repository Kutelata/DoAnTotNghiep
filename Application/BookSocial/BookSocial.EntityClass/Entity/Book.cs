using System.ComponentModel.DataAnnotations;

namespace BookSocial.EntityClass.Entity
{
    public class Book : BaseEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Isbn is required")]
        [RegularExpression("^[A-Za-z0-9]+$", ErrorMessage = "Isbn is wrong format")]
        public string Isbn { get; set; }
        [Required(ErrorMessage = "Book Name is required")]
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int? PageNumber { get; set; }
        public DateTime? Published { get; set; }
        [Required(ErrorMessage = "Genre Name is required")]
        public int GenreId { get; set; }
    }
}