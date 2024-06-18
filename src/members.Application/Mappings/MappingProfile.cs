using AutoMapper;
using members.Database.Domain.Entities;
using members.Domain.Dtos;
using members.Domain.Requests;

namespace members.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Member, MemberDto>();
            CreateMap<AddMemberRequest, Member>();
        }
    }
}
