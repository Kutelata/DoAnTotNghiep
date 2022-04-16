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
        }
    }
}
