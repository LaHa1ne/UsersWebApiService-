using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersWebApiService.DataLayer.Entities;

namespace UsersWebApiService.DataAccessLayer.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<IEnumerable<User>> GetUsersOnSelectedPage(int selected_page, int page_size);
        Task<int> GetAllUsersCount();
        Task<IEnumerable<User>> GetActiveUsers();
        Task<IEnumerable<User>> GetActiveUsersOnSelectedPage(int selected_page, int page_size);
        Task<int> GetActiveUsersCount();
        Task<User> GetUserByLogin(string Login);
        Task<User> GetUserById(Guid Guid);
        Task<User> GetUserByLoginAndPassword(string Login, string HashPassword);
        Task<User> GetAdminUser();
    }
}
