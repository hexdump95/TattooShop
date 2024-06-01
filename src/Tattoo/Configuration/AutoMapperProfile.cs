using AutoMapper;

using Tattoo.DTOs;
using Tattoo.Entities;

namespace Tattoo.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterRequest, User>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(
                        _ => Guid.NewGuid().ToString()
                    )
                )
                .ForMember(dest => dest.Password,
                    opt => opt.MapFrom(
                        src => BCrypt.Net.BCrypt.HashPassword(src.Password)
                    )
                )
                .ForMember(dest => dest.UserRoles,
                    opt => opt.MapFrom(
                        _ => new List<UserRole> { new() { Role = Role.USER } }
                    )
                )
                ;
        }
    }
}
