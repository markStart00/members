using AutoMapper;
using members.Database.Domain.Entities;
using members.Domain.Dtos;

namespace members.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Member, MemberDto>();
        }
    }
}
