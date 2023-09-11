﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolMonitor.ApplicationServices.API.Domain.Users
{
    public class GetUserByIdRequest : RequestBase<GetUserByIdResponse>
    {
        public int UserId { get; set; }
    }
}
