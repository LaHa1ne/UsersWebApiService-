using AutoMapper;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersWebApiService.Controllers;
using UsersWebApiService.DataAccessLayer;
using UsersWebApiService.DataAccessLayer.Implementations;
using UsersWebApiService.DataAccessLayer.Interfaces;
using UsersWebApiService.DataLayer.Mappers;
using UsersWebApiService.Services.Implementations;
using UsersWebApiService.Services.Interfaces;

namespace UsersWebApiService.Tests
{
    public abstract class TestWithSqlite : IDisposable
    {
        private const string InMemoryConnectionString = "DataSource=:memory:";
        private readonly SqliteConnection _connection;

        protected readonly ApplicationDbContext _context;
        protected readonly IUserRepository _userRepository;
        protected readonly IUser_groupRepository _user_groupRepository;
        protected readonly IUser_stateRepository _user_stateRepository;
        protected readonly IMapper _mapper;
        protected readonly IUsersService _usersService;
        protected readonly ILogger<UsersController> _logger;
        protected readonly UsersController _usersController;

        protected TestWithSqlite()
        {
            //creation ApplicationDbContext
            _connection = new SqliteConnection(InMemoryConnectionString);
            _connection.Open();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlite(_connection)
                    .Options;
            _context = new ApplicationDbContext(options);
            _context.Database.EnsureCreated();

            //creation Repositories & mappers
            _userRepository = new UserRepository(_context);
            _user_groupRepository = new User_groupRepository(_context);
            _user_stateRepository = new User_stateRepository(_context);
            MapperConfiguration mapperConfig = new MapperConfiguration(
            cfg =>
            {
                cfg.AddProfile(new User_groupToUser_groupDTOMapperProfile());
                cfg.AddProfile(new User_stateToUser_stateDTOMapperProfile());
                cfg.AddProfile(new UserToUserDTOMapperProfile());
                cfg.AddProfile(new CreatedUserDTOToUserMapperProfile());
            });
            _mapper = mapperConfig.CreateMapper();

            //creation UsersService
            _usersService = new UsersService(_mapper, _userRepository, _user_groupRepository, _user_stateRepository);

            //creation UsersController using fake logger
            var mock = new Mock<ILogger<UsersController>>();
            _logger = mock.Object;
            _usersController = new UsersController(_logger, _usersService);



        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}
