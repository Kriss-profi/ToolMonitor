using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.ApplicationServices.API.Domain.Models;

namespace ToolMonitor.ApplicationServices.API.Mappings
{
    public class ToolsProfile : Profile
    {
        public ToolsProfile()
        {
            this.CreateMap<DataAccess.Entities.Tool, Tool>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.ToolName, y => y.MapFrom(z => z.ToolName));
                //.ForMember(x => x.Description, y => y.MapFrom(z => z.ToolDescription));
        }
    }
}
