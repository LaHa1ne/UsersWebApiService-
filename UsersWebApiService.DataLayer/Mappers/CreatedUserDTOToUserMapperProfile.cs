using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersWebApiService.DataLayer.DTO;
using UsersWebApiService.DataLayer.Entities;
using UsersWepApiService.DataLayer.Helpers;

namespace UsersWebApiService.DataLayer.Mappers
{
    public class CreatedUserDTOToUserMapperProfile : Profile
    {
        public CreatedUserDTOToUserMapperProfile()
        {
            CreateMap<CreatedUserDTO, User>()
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => HashPasswordHelper.GetHashPassword(src.Password)));
                
        }
    }
}
