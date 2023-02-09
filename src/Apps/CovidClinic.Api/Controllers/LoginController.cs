using System.Threading;
using System.Threading.Tasks;
using CovidClinic.Application.ApplicationUser.Queries.GetToken;
using CovidClinic.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace CovidClinic.Api.Controllers
{
    /// <summary>
    /// Login
    /// </summary>
    public class LoginController : BaseApiController
    {
        /// <summary>
        /// Login and get JWT token email: akazad@demo.com password: 11!!qqQQ
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ServiceResult<LoginResponse>>> Login(GetTokenQuery query, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(query, cancellationToken));
        }
    }
}
