﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersWebApiService.DataLayer.Enums;

namespace UsersWebApiService.DataLayer.Responses
{
    public class BaseRepsonse<Tobject> : IBaseResponse<Tobject>
    {
        public string Description { get; set; } = null!;
        public StatusCode StatusCode { get; set; }
        public Tobject? Data { get; set; }

        public BaseRepsonse()
        {
        }
        public BaseRepsonse(string Description, StatusCode StatusCode)
        {
            this.Description = Description;
            this.StatusCode = StatusCode;
        }
    }

    public interface IBaseResponse<Tobject>
    {
        Tobject? Data { get; set; }
    }
}
