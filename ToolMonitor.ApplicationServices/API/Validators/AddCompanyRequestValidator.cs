using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitor.ApplicationServices.API.Domain.Companies;

namespace ToolMonitor.ApplicationServices.API.Validators
{
    public class AddCompanyRequestValidator : AbstractValidator<AddCompanyRequest>
    {
        public AddCompanyRequestValidator()
        {
            this.RuleFor(x => x.CompanyName).Length(1, 100);
            this.RuleFor(x => x.CompanyCity).Length(1, 50);
        }
    }
}
