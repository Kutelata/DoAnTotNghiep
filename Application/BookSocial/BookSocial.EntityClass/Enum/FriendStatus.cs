using System.ComponentModel.DataAnnotations;

namespace BookSocial.EntityClass.Enum
{
    public enum FriendStatus
    {
        [Display(Name = "Gợi ý bạn bè")]
        Suggest = 0,
        [Display(Name = "Lời mời kết bạn")]
        Request = 1,
        [Display(Name = "Bạn bè")]
        Friends = 2
    }
}
