using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.ApplicationServices.API.Domain.Models;

namespace ToolMonitor.ApplicationServices.API.Mappings
{
    public class CategoriesProfile : Profile
    {
        public CategoriesProfile()
        {
            this.CreateMap<DataAccess.Entities.Category, Category>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                //.ForMember(x => x.CompanyId, y => y.MapFrom(z => z.CompanyId))
                .ForMember(x => x.CategoryName, y => y.MapFrom(z => z.CategoryName));


            this.CreateMap<Category, DataAccess.Entities.Category>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                //.ForMember(x => x.CompanyId, y => y.MapFrom(z => z.CompanyId))
                .ForMember(x => x.CategoryName, y => y.MapFrom(z => z.CategoryName));
        }
    }
}
