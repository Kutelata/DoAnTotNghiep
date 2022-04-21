using System.ComponentModel.DataAnnotations;

namespace BookSocial.EntityClass.Enum
{
    public enum ProgressRead
    {
        [Display(Name = "Want To Read")]
        WantToRead = 0,
        [Display(Name = "Currently Reading")]
        CurrentlyReading = 1,
        [Display(Name = "Read")]
        Read = 2
    }
}
