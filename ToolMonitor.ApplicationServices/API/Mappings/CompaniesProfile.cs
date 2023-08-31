using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.ApplicationServices.API.Domain.Companies;
using ToolMonitor.ApplicationServices.API.Domain.Models;

namespace ToolMonitor.ApplicationServices.API.Mappings
{
    public class CompaniesProfile : Profile
    {
        public CompaniesProfile()
        {
            this.CreateMap<DataAccess.Entities.Company, Company>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.CompanyName, y => y.MapFrom(z => z.CompanyName))
                .ForMember(x => x.CompanyCity, y => y.MapFrom(z => z.CompanyCity))
                ;

            this.CreateMap<PutCompanyRequest, DataAccess.Entities.Company>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.CompanyId))
                .ForMember(x => x.CompanyName, y => y.MapFrom(z => z.CompanyName))
                .ForMember(x => x.CompanyCity, y => y.MapFrom(z => z.CompanyCity))
                ;

            this.CreateMap<AddCompanyRequest, DataAccess.Entities.Company>()
                .ForMember(x => x.CompanyName, y => y.MapFrom(z => z.CompanyName))
                .ForMember(x => x.CompanyCity, y => y.MapFrom(z => z.CompanyCity))
                ;

            this.CreateMap<Company, DataAccess.Entities.Company>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.CompanyName, y => y.MapFrom(z => z.CompanyName))
                .ForMember(x => x.CompanyCity, y => y.MapFrom(z => z.CompanyCity))
                ;

        }
    }
}
