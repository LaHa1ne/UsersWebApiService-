using UsersWebApiService.DataLayer.DTO;
using UsersWebApiService.DataLayer.Enums;
using UsersWebApiService.DataLayer.Responses;

namespace UsersWebApiService.Tests.ControllersTest
{
    public class ApplicationsDbContextTests : TestWithSqlite
    {
        //
        //GetUsers
        //
        [Fact]
        public async void GetAllUsers_ReturnUserDTOListOf15Users()
        {
            // Arrange

            // Act
            var response = await _usersController.GetAllUsers();
            var value = response.Value as BaseRepsonse<List<UserDTO>>;
            var data = value?.Data;

            // Assert
            Assert.Equal(15, data?.Count);
        }

        [Fact]
        public async void GetActiveUsers_ReturnUserDTOListOf11Users()
        {
            // Arrange

            // Act
            var response = await _usersController.GetActiveUsers();
            var value = response.Value as BaseRepsonse<List<UserDTO>>;
            var data = value?.Data;

            // Assert
            Assert.Equal(11, data?.Count);
        }

        //
        //CreateUser
        //
        [Fact]
        public async void CreateUser_TryToAddFirstAdmin_ReturnUserIdAndOKStatus()
        {
            // Arrange
            var adminUser = new CreatedUserDTO()
            {
                Login = "Admin",
                Password = "Password",
                Group_Code = group_code.Admin,
            };

            // Act
            var response = await _usersController.CreateUser(adminUser);
            var value = response.Value as BaseRepsonse<Guid>;
            var data = value?.Data;

            // Assert
            Assert.Equal((int)StatusCode.Created, (int)response.StatusCode);
            Assert.NotEqual(data, Guid.Empty);
            Assert.Equal(16, _context.Users.Count());
        }

        [Fact]
        public async void CreateUser_TryToAddSecondAdmin_ReturnEmptyUserIdAndBasRequestStatus()
        {
            // Arrange
            var adminUser1 = new CreatedUserDTO()
            {
                Login = "Admin2",
                Password = "Password2",
                Group_Code = group_code.Admin,
            };
            var adminUser2 = new CreatedUserDTO()
            {
                Login = "Admin3",
                Password = "Password3",
                Group_Code = group_code.Admin,
            };


            // Act
            _ = await _usersController.CreateUser(adminUser1);
            var response = await _usersController.CreateUser(adminUser2);
            var value = response.Value as BaseRepsonse<Guid>;
            var data = value?.Data;

            // Assert
            Assert.Equal((int)StatusCode.BadRequest, (int)response.StatusCode);
            Assert.Equal(data, Guid.Empty);
            Assert.Equal(16, _context.Users.Count());
        }

        [Fact]
        public async void CreateUser_TryToAddUsersWithSameLogins_ReturnEmptyUserIdAndBasRequestStatus()
        {
            // Arrange
            var newUser1 = new CreatedUserDTO()
            {
                Login = "newUser",
                Password = "Password1",
                Group_Code = group_code.User,
            };
            var newUser2 = new CreatedUserDTO()
            {
                Login = "newUser",
                Password = "Password2",
                Group_Code = group_code.User,
            };


            // Act
            _ = await _usersController.CreateUser(newUser1);
            var response = await _usersController.CreateUser(newUser2);
            var value = response.Value as BaseRepsonse<Guid>;
            var data = value?.Data;

            // Assert
            Assert.Equal((int)StatusCode.BadRequest, (int)response.StatusCode);
            Assert.Equal(data, Guid.Empty);
            Assert.Equal(16, _context.Users.Count());
        }

        //
        //GetUser
        //
        [Fact]
        public async void GetUserByLogin_ReturnUserWithSelectedLoginAndOKStatusIfUserExists()
        {
            // Arrange
            var newUser = new CreatedUserDTO()
            {
                Login = "newUser",
                Password = "Password",
                Group_Code = group_code.User,
            };

            // Act
            _ = await _usersController.CreateUser(newUser);
            var response = await _usersController.GetUserByLogin(newUser.Login);
            var value = response.Value as BaseRepsonse<UserDTO>;
            var data = value?.Data;

            // Assert
            Assert.Equal((int)StatusCode.OK, (int)response.StatusCode);
            Assert.Equal(newUser.Login, data.Login);
            Assert.Equal(group_code.User, data.User_group.Code);
            Assert.Equal(state_code.Active, data.User_state.Code);
        }

        //
        //DeleteUser
        //
        [Fact]
        public async void DeleteUserByLogin_ReturnTrueAndOKStatusIfUserExists()
        {
            // Arrange
            var newUser = new CreatedUserDTO()
            {
                Login = "newUser",
                Password = "Password",
                Group_Code = group_code.User,
            };

            // Act
            _ = await _usersController.CreateUser(newUser);

            var response_ActiveUsersBeforeDelete = await _usersController.GetActiveUsers();
            var value_ActiveUsersBeforeDelete = response_ActiveUsersBeforeDelete.Value as BaseRepsonse<List<UserDTO>>;
            var ActiveUsersBeforeDeleteCount = value_ActiveUsersBeforeDelete.Data.Count;

            var response = await _usersController.DeleteUserByLogin(newUser.Login);
            var value = response.Value as BaseRepsonse<bool>;
            var data = value?.Data;

            var response_ActiveUsersAfterDelete = await _usersController.GetActiveUsers();
            var value_ActiveUsersAfterDelete = response_ActiveUsersAfterDelete.Value as BaseRepsonse<List<UserDTO>>;
            var ActiveUsersAfterDeleteCount = value_ActiveUsersAfterDelete.Data.Count;

            // Assert
            Assert.Equal((int)StatusCode.OK, (int)response.StatusCode);
            Assert.Equal(true, data);
            Assert.Equal(12, ActiveUsersBeforeDeleteCount);
            Assert.Equal(11, ActiveUsersAfterDeleteCount);
        }
    }
}