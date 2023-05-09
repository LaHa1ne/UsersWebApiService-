using Microsoft.EntityFrameworkCore;
using UsersWebApiService.DataAccessLayer.Interfaces;
using UsersWebApiService.DataLayer.Entities;
using UsersWebApiService.DataLayer.Enums;

namespace UsersWebApiService.DataAccessLayer.Implementations
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext db) : base(db)
        {
        }
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _db.Users.Include(u => u.User_group).Include(u => u.User_state).AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<User>> GetUsersOnSelectedPage(int selected_page, int page_size)
        {
            return await _db.Users.Skip((selected_page - 1) * page_size).Take(page_size).Include(u => u.User_group).Include(u => u.User_state)
                .AsNoTracking().ToListAsync();
        }
        public async Task<int> GetAllUsersCount()
        {
            return await _db.Users.CountAsync();
        }
        public async Task<IEnumerable<User>> GetActiveUsers()
        {
            return await _db.Users.Include(u => u.User_group).Include(u => u.User_state).Where(u=>u.User_state.Code == state_code.Active).AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<User>> GetActiveUsersOnSelectedPage(int selected_page, int page_size)
        {
            return await _db.Users.Skip((selected_page - 1) * page_size).Take(page_size).Include(u => u.User_group).Include(u => u.User_state).Where(u => u.User_state.Code == state_code.Active).AsNoTracking().ToListAsync();
        }
        public async Task<int> GetActiveUsersCount()
        {
            return await _db.Users.Include(u => u.User_state).Where(u => u.User_state.Code == state_code.Active).CountAsync();
        }
        public async Task<User> GetUserByLogin(string Login)
        {
            return await _db.Users.Include(u => u.User_group).Include(u => u.User_state).SingleOrDefaultAsync(u=>u.Login == Login);
        }
        public async Task<User> GetUserById(Guid Id)
        {
            return await _db.Users.Include(u => u.User_group).Include(u => u.User_state).SingleOrDefaultAsync(u => u.Id == Id);
        }
        public async Task<User> GetUserByLoginAndPassword(string Login, string HashPassword)
        {
            var user = await _db.Users.Include(u => u.User_group).Include(u => u.User_state).SingleOrDefaultAsync(u => u.Login == Login);
            return (user == null ) ? null : user.Password == HashPassword ? user : null;
        }
        public async Task<User> GetAdminUser()
        {
            return await _db.Users.Include(u => u.User_group).Include(u => u.User_state).SingleOrDefaultAsync(u => u.User_group.Code == group_code.Admin);
        }


    }
}
