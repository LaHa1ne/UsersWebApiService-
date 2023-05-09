using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersWebApiService.DataLayer.Entities;
using UsersWebApiService.DataLayer.Enums;

namespace UsersWebApiService.DataLayer.DTO
{
    public class User_stateDTO
    {
        public int Id { get; set; }
        public state_code Code { get; set; }
        public string Description { get; set; } = null!;

    }
}
