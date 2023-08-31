﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolMonitor.ApplicationServices.API.Domain.Departments
{
    public class DeleteDepartmentRequest :IRequest<DeleteDepartmentResponse>
    {
        public int Id { get; set; }
    }
}