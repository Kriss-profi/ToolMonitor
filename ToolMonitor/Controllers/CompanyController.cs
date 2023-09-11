using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToolMonitor.ApplicationServices.API.Domain.Companies;

namespace ToolMonitor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ApiControllerBase
    {
        public CompanyController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllCompanies([FromQuery] GetCompanyRequest request)
        {
            return this.HandleRequest<GetCompanyRequest, GetCompanyResponse>(request);
        }

        [HttpGet]
        [Route("{companyId}")]
        public Task<IActionResult> GetCompanyById([FromRoute] int companyId)
        {
            var request = new GetCompanyByIdRequest()
            {
                Id = companyId,
            };
            return this.HandleRequest<GetCompanyByIdRequest, GetCompanyByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddCompany([FromBody] AddCompanyRequest request)
        {
            return this.HandleRequest<AddCompanyRequest, AddCompanyResponse>(request);
        }

        [HttpPut]
        [Route("")]
        public Task<IActionResult> PutCompany([FromBody] PutCompanyRequest request)
        {
            return this.HandleRequest<PutCompanyRequest, PutCompanyResponse>(request);
        }

        [HttpDelete]
        [Route("{companyId}")]
        public Task<IActionResult> DeleteCompany([FromRoute] int companyId)
        {
            var request = new DeleteCompanyRequest()
            {
                CompanyId = companyId,
            };
            return this.HandleRequest<DeleteCompanyRequest, DeleteCompanyResponse>(request);
        }
    }
}
