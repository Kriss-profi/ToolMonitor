﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.ApplicationServices.API.Domain.Models;
using ToolMonitor.ApplicationServices.API.Domain.Users;

namespace ToolMonitor.ApplicationServices.API.Mappings
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            this.CreateMap<DataAccess.Entities.User, User>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.CompanyId, y => y.MapFrom(z => z.CompanyId))
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email))
                //.ForMember(x => x.UserStatus, y => y.MapFrom(z => z.UserStatus))
                ;

            this.CreateMap<User, DataAccess.Entities.User>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.CompanyId, y => y.MapFrom(z => z.CompanyId))
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email))
                //.ForMember(x => x.UserStatus, y => y.MapFrom(z => z.UserStatus))
                ;

            this.CreateMap<AddUserRequest, DataAccess.Entities.User>()
                .ForMember(x => x.CompanyId, y => y.MapFrom(z => z.CompanyId))
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email))
                .ForMember(x => x.UserStatus, y => y.MapFrom(z => z.UserStatus))
                ;

            this.CreateMap<PutUserRequest, DataAccess.Entities.User>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.CompanyId, y => y.MapFrom(z => z.CompanyId))
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email))
                .ForMember(x => x.Password, y => y.MapFrom(z => z.Password))
                .ForMember(x => x.UserStatus, y => y.MapFrom(z => z.UserStatus))
                ;
        }
    }
}
