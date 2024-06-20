using AutoMapper;
using members.Application.Extensions;
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

            CreateMap<Party, PartyDto>();

            CreateMap<AddMemberRequest, Member>()
                .ForMember(dest => dest.NameFullTitle, opt => opt.MapFrom(src => src.NameFullTitle.NormalizeToLowerCase()))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.NormalizeToLowerCase()))

                .ForMember(dest => dest.MembershipStartDate, opt => opt.MapFrom(src => DateTime.Parse(src.MembershipStartDate)))

                .ForMember(dest => dest.MembershipEndDate, opt => opt.MapFrom(src =>
                    string.IsNullOrWhiteSpace(src.MembershipEndDate) ? (DateTime?)null : DateTime.Parse(src.MembershipEndDate)))

                .ForMember(dest => dest.MembershipEndReason, opt => opt.MapFrom(src => src.MembershipEndReason.NormalizeToLowerCase()))

                .ForMember(dest => dest.MemberFrom, opt => opt.MapFrom(src => src.MemberFrom.NormalizeToLowerCase()));

        }
    }
}
