using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.ApplicationServices.API.Domain.Manufacturers;
using ToolMonitor.ApplicationServices.API.Domain.Models;

namespace ToolMonitor.ApplicationServices.API.Mappings
{
    public class ManufacturersProfile : Profile
    {
        public ManufacturersProfile()
        {
            this.CreateMap<DataAccess.Entities.Manufacturer, Manufacturer>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Web, y => y.MapFrom(z => z.Web))
                ;

            this.CreateMap<Manufacturer, DataAccess.Entities.Manufacturer>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Web, y => y.MapFrom(z => z.Web))
                ;

            this.CreateMap<AddManufacturerRequest, DataAccess.Entities.Manufacturer>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Web, y => y.MapFrom(z => z.Web))
                ;


            this.CreateMap<PutManufacturerRequest, DataAccess.Entities.Manufacturer>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Web, y => y.MapFrom(z => z.Web))
                ;
        }
    }
}
