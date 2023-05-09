using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersWebApiService.DataLayer.DTO
{
    public class UsersPageDTO
    {
        public List<UserDTO> Users { get; set; } = null!;
        public int SelectedPage { get; set;}
        public int PageCount { get; set;}
    }
}
