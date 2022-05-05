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

            CreateMap<Shelf, ShelfWithProgressOrigin>().ForMember(
                des => des.ProgressReadOrigin, 
                act => act.MapFrom(src => src.ProgressRead));
            CreateMap<ShelfWithProgressOrigin, Shelf>().ForMember(
                des => des.ProgressRead, 
                act => act.MapFrom(src => src.ProgressReadOrigin));
        }
    }
}
