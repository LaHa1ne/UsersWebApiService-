using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersWebApiService.DataAccessLayer.DbConfigurations;
using UsersWebApiService.DataAccessLayer.Interfaces;
using UsersWebApiService.DataLayer.Entities;
using UsersWebApiService.DataLayer.Enums;

namespace UsersWebApiService.DataAccessLayer.Implementations
{
    public class User_groupRepository : IUser_groupRepository
    {
        protected readonly ApplicationDbContext _db;

        public User_groupRepository(ApplicationDbContext db) => _db = db;

        public async Task<int> GetUser_groupIdByCode(group_code group_code)
        {
            var User_group = await _db.User_groups.AsNoTracking().SingleOrDefaultAsync(u => u.Code == group_code);
            return User_group!.Id;
        }
    }
}
