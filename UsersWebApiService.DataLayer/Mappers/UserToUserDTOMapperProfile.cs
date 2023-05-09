using AutoMapper;
using UsersWebApiService.DataLayer.DTO;
using UsersWebApiService.DataLayer.Entities;

namespace UsersWebApiService.DataLayer.Mappers
{
    public class UserToUserDTOMapperProfile : Profile
    {
        public UserToUserDTOMapperProfile() 
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
                .ForMember(dest => dest.HashPassword, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.Created_date))
                .ForMember(dest => dest.User_group, opt => opt.MapFrom(src => src.User_group))
                .ForMember(dest => dest.User_state, opt => opt.MapFrom(src => src.User_state));
        }
    }
}
