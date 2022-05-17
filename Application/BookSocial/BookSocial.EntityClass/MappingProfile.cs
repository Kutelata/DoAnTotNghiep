using AutoMapper;
using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;

namespace BookSocial.EntityClass
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CRUDEmployee, User>();
            CreateMap<User, CRUDEmployee>();

            CreateMap<UserRegister, User>();
            CreateMap<User, UserRegister>();

            CreateMap<Shelf, ShelfWithProgressOrigin>()
                .ForMember(des => des.ProgressReadOrigin, act => act.MapFrom(src => src.ProgressRead));
            CreateMap<ShelfWithProgressOrigin, Shelf>()
                .ForMember(des => des.ProgressRead, act => act.MapFrom(src => src.ProgressReadOrigin));

            CreateMap<FriendList, FriendListHome>()
                .ForMember(des => des.UserFriendId, act => act.MapFrom(src => src.Id))
                .ForMember(des => des.UserFriendName, act => act.MapFrom(src => src.Name));
            CreateMap<FriendListHome, FriendList>()
                .ForMember(des => des.Id, act => act.MapFrom(src => src.UserFriendId))
                .ForMember(des => des.Name, act => act.MapFrom(src => src.UserFriendName));

            CreateMap<Author, AuthorProfile>();
            CreateMap<AuthorProfile, Author>(); 
            
            CreateMap<Comment, CommentInReview>();
            CreateMap<CommentInReview, Comment>();
        }
    }
}
