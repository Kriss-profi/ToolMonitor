using System;
using System.Text;
using System.Text.Encodings.Web;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ToolMonitor.DataAccess;
using ToolMonitor.DataAccess.CQRS;
using ToolMonitor.DataAccess.CQRS.Queries;
using ToolMonitor.DataAccess.Entities;
using Microsoft.Extensions.Options;

namespace ToolMonitor.Authentication
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly AccessCompany accessCompany;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IQueryExecutor queryExecutor,
            AccessCompany accessCompany)
            : base(options, logger, encoder, clock)
        {
            this.queryExecutor = queryExecutor;
            this.accessCompany = accessCompany;
        }

        public ClaimsIdentity? Status { get; private set; }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // skip authentication if endpoint has [AllowAnonymous] attribute
            var endpoint = Context.GetEndpoint();
            if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
            {
                return AuthenticateResult.NoResult();
            }

            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Missing Authorization Header");
            }

            User user = null;
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
                var email = credentials[0];
                var password = credentials[1];
                var query = new GetUserQuery()
                {
                    Email = email,
                    
                };
                user = await this.queryExecutor.Execute(query);

                // TODO: HASH!
                if (user == null || user.Password != password)
                {
                    return AuthenticateResult.Fail("Invalid Authorization Header");
                }

            }
            catch
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }
            accessCompany.CompanyId = (int)user.CompanyId;
            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.LastName),
                new Claim(ClaimTypes.SerialNumber, user.CompanyId.ToString()),
                //new Claim(ClaimTypes.Role, user.UserStatus.ToString()),
            };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return AuthenticateResult.Success(ticket);
        }
    }
}
