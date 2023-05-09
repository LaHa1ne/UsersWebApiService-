using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersWebApiService.DataAccessLayer.Interfaces;
using UsersWebApiService.DataLayer.Entities;
using UsersWebApiService.DataLayer.Enums;

namespace UsersWebApiService.DataAccessLayer.Implementations
{
    public class User_stateRepository : IUser_stateRepository
    {
        protected readonly ApplicationDbContext _db;
        public User_stateRepository(ApplicationDbContext db) => _db = db;

        public async Task<int> GetUser_stateIdByCode(state_code state_code)
        {
            var User_state = await _db.User_states.AsNoTracking().SingleOrDefaultAsync(u => u.Code == state_code);
            return User_state!.Id;
        }
    }
}
