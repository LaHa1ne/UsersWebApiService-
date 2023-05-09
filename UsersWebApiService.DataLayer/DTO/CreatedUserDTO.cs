using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersWebApiService.DataLayer.Enums;

namespace UsersWebApiService.DataLayer.DTO
{
    public class CreatedUserDTO
    {
        [Required]
        public string Login { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public group_code Group_Code { get; set; }

    }
}
