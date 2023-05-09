using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersWebApiService.DataLayer.Entities;
using UsersWebApiService.DataLayer.Enums;

namespace UsersWebApiService.DataAccessLayer.Interfaces
{
    public interface IUser_stateRepository
    {
        Task<int> GetUser_stateIdByCode(state_code state_code);

    }
}
