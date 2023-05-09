using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersWebApiService.DataLayer.Entities;

namespace UsersWebApiService.DataLayer.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Login { get; set; } = null!;
        public string HashPassword { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public User_groupDTO User_group { get; set; } = null!;
        public User_stateDTO User_state { get; set; } = null!;

    }
}
