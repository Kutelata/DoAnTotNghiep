using System.ComponentModel.DataAnnotations;

namespace BookSocial.EntityClass.Entity
{
    public class Book : BaseEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Isbn không được để trống")]
        [RegularExpression("^[A-Za-z0-9]+$", ErrorMessage = "Isbn là chuỗi không có dấu")]
        public string Isbn { get; set; }
        [Required(ErrorMessage = "Tên sách không được để trống")]
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int? PageNumber { get; set; }
        public DateTime? Published { get; set; }
        [Required(ErrorMessage = "Thể loại không được để trống")]
        public int GenreId { get; set; }
    }
}