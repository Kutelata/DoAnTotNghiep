using System.ComponentModel.DataAnnotations;

namespace BookSocial.EntityClass.Enum
{
    public enum ProgressRead
    {
        [Display(Name = "Muốn đọc")]
        WantToRead = 0,
        [Display(Name = "Đang đọc")]
        CurrentlyReading = 1,
        [Display(Name = "Đã đọc")]
        Read = 2
    }
    
    public enum ProgressReadFilter
    {
        [Display(Name = "Tất cả")]
        All = -1,
        [Display(Name = "Muốn đọc")]
        WantToRead = 0,
        [Display(Name = "Đang đọc")]
        CurrentlyReading = 1,
        [Display(Name = "Đã đọc")]
        Read = 2
    }

    public enum ProgressReadOrigin
    {
        [Display(Name = "Chưa đọc")]
        NotRead = -1,
        [Display(Name = "Muốn đọc")]
        WantToRead = 0,
        [Display(Name = "Đang đọc")]
        CurrentlyReading = 1,
        [Display(Name = "Đã đọc")]
        Read = 2
    }
}
