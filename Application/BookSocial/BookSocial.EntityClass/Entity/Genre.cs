using System.ComponentModel.DataAnnotations;

namespace BookSocial.EntityClass.Entity
{
    public class Genre : BaseEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên thể loại không được để trống")]
        public string Name { get; set; }
    }
}
