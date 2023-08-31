using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToolMonitor.ApplicationServices.API.Domain.Companies;

namespace ToolMonitor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator mediator;

        public CompanyController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllCompanies([FromQuery] GetCompanyRequest request)
        {
            var response = await this.mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("{companyId}")]
        public async Task<IActionResult> GetCompanyById([FromRoute] int companyId)
        {
            var request = new GetCompanyByIdRequest()
            {
                Id = companyId,
            };
            var response = await this.mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddCompany([FromBody] AddCompanyRequest request)
        {
            var response = await this.mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> PutCompany([FromBody] PutCompanyRequest request)
        {
            var response = await this.mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{companyId}")]
        public async Task<IActionResult> DeleteCompany([FromRoute] int companyId)
        {
            var request = new DeleteCompanyRequest()
            {
                CompanyId = companyId,
            };
            var response = await this.mediator.Send(request);
            return Ok(response);
        }
    }
}
