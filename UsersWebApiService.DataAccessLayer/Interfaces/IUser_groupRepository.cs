using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersWebApiService.DataLayer.Entities;
using UsersWebApiService.DataLayer.Enums;

namespace UsersWebApiService.DataAccessLayer.Interfaces
{
    public interface IUser_groupRepository
    {
        Task<int> GetUser_groupIdByCode(group_code group_code);

    }
}
