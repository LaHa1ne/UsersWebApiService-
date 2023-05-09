using AutoMapper;
using UsersWebApiService.DataLayer.DTO;
using UsersWebApiService.DataLayer.Entities;

namespace UsersWebApiService.DataLayer.Mappers
{
    public class User_groupToUser_groupDTOMapperProfile : Profile
    {
        public User_groupToUser_groupDTOMapperProfile()
        {
            CreateMap<User_group, User_groupDTO>();
        }
    }
}
