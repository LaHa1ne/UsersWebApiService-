using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersWebApiService.DataAccessLayer.Implementations;
using UsersWebApiService.DataAccessLayer.Interfaces;
using UsersWebApiService.DataAccessLayer;
using UsersWebApiService.Services.Interfaces;
using UsersWebApiService.Controllers;
using UsersWebApiService.DataLayer.Mappers;
using UsersWebApiService.Services.Implementations;

namespace UsersWebApiService.Tests2.Controllers
{
    public class UsersControllerTests
    {
        protected readonly ApplicationDbContext _dbContext;
        protected readonly IUserRepository _userRepository;
        protected readonly IUser_groupRepository _user_groupRepository;
        protected readonly IUser_stateRepository _user_stateRepository;
        protected readonly IUsersService _usersService;
        protected readonly ILogger<UsersController> _logger;
        protected readonly UsersController _usersController;
        protected readonly IMapper _mapper;

        public UsersControllerTests()
        {
            _dbContext = ApplicationDbContextFactory.Create();
            MapperConfiguration mapperConfig = new MapperConfiguration(
            cfg =>
            {
                cfg.AddProfile(new CreatedUserDTOToUserMapperProfile());
                cfg.AddProfile(new UserToUserDTOMapperProfile());
            });
            _userRepository = new UserRepository(_dbContext);
            _user_groupRepository = new User_groupRepository(_dbContext);
            _user_stateRepository = new User_stateRepository(_dbContext);
            _mapper = new Mapper(mapperConfig);
            _usersService = new UsersService(_mapper, _userRepository, _user_groupRepository, _user_stateRepository);
            _usersController = new UsersController(_logger!, _usersService);
        }

        [Fact]
        public async void GetAllUsersTest()
        {


            /*var _usersService = new Mock<IUsersService>();
            _usersService.Setup(s=>s.GetAllUsers()).ReturnsAsync(new BaseRepsonse<List<DataLayer.DTO.UserDTO>>() { Data = CreateFakeData.GetFakeUserDTOs()});

            var result = await _usersController.GetAllUsers();*/

            var result = await _usersController.GetAllUsers();

            Assert.Equal(5, 15);
            ApplicationDbContextFactory.Destroy(_dbContext);

        }

        [Fact]
        public void Test2()
        {


            /*var _usersService = new Mock<IUsersService>();
            _usersService.Setup(s=>s.GetAllUsers()).ReturnsAsync(new BaseRepsonse<List<DataLayer.DTO.UserDTO>>() { Data = CreateFakeData.GetFakeUserDTOs()});

            var result = await _usersController.GetAllUsers();*/

            Assert.Equal(5, 15);

        }



        /* [Fact]
         public async Task UsersControllerGetAll_ReturnsListOfUsers()
         {


         }*/




    }
}
