using System.ComponentModel.DataAnnotations;

namespace BookSocial.EntityClass.Entity
{
    public class Genre : BaseEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Genre Name is required")]
        public string Name { get; set; }
    }
}
