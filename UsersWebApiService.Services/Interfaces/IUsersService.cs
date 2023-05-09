using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersWebApiService.DataLayer.DTO;
using UsersWebApiService.DataLayer.Responses;

namespace UsersWebApiService.Services.Interfaces
{
    public interface IUsersService
    {
        Task<BaseRepsonse<Guid>> CreateUser(CreatedUserDTO CreatedUserInfo);
        Task<BaseRepsonse<List<UserDTO>>> GetAllUsers();
        Task<BaseRepsonse<UsersPageDTO>> GetUsersOnSelectedPage(int selected_page);
        Task<BaseRepsonse<List<UserDTO>>> GetActiveUsers();
        Task<BaseRepsonse<UsersPageDTO>> GetActiveUsersOnSelectedPage(int selected_page);
        Task<BaseRepsonse<UserDTO>> GetUserByLogin(string Login);
        Task<BaseRepsonse<UserDTO>> GetUserById(Guid Id);
        Task<BaseRepsonse<bool>> IsUserExistsByLoginAndPassword(string Login, string Password);
        Task<BaseRepsonse<bool>> DeleteUserByLogin(string Login);
        Task<BaseRepsonse<bool>> DeleteUserById(Guid Id);

    }
}
