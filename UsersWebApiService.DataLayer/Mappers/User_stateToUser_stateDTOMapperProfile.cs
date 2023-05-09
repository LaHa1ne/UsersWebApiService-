using AutoMapper;
using UsersWebApiService.DataLayer.DTO;
using UsersWebApiService.DataLayer.Entities;

namespace UsersWebApiService.DataLayer.Mappers
{
    public class User_stateToUser_stateDTOMapperProfile : Profile
    {
        public User_stateToUser_stateDTOMapperProfile()
        {
            CreateMap<User_state, User_stateDTO>();
        }
    }
}
