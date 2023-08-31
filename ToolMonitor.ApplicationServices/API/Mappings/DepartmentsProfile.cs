using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.ApplicationServices.API.Domain.Models;

namespace ToolMonitor.ApplicationServices.API.Mappings
{
    public class DepartmentsProfile : Profile
    {
        public DepartmentsProfile()
        {
            this.CreateMap<DataAccess.Entities.Department, Department>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.DepartmentName, y => y.MapFrom(z => z.DepartmentName))
                ;

            this.CreateMap<Department, DataAccess.Entities.Department>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.DepartmentName, y => y.MapFrom(z => z.DepartmentName))
                ;
        }
    }
}
