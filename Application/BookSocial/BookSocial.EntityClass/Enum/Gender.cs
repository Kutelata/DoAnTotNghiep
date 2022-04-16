using System.ComponentModel.DataAnnotations;

namespace BookSocial.EntityClass.Enum
{
    public enum Gender
    {
        [Display(Name = "Male")]
        Male = 0,
        [Display(Name = "Female")]
        Female = 1,
        [Display(Name = "Others")]
        Others = 2
    }
}
