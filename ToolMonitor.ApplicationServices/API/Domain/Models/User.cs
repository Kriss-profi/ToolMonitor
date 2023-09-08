using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.DataAccess.Entities;

namespace ToolMonitor.ApplicationServices.API.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public int? CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        //public string Password { get; set; }
        public UserStatus UserStatus { get; set; }

        //public static implicit operator User(DataAccess.Entities.User v)
        //{
        //    throw new NotImplementedException();
        //}

    }
}
