using System.Threading;
using System.Threading.Tasks;
using CovidClinic.Application.Common.Models;
using CovidClinic.Domain.Enums;

namespace CovidClinic.Application.Common.Interfaces
{
    public interface IHttpClientHandler
    {
        Task<ServiceResult<TResult>> GenericRequest<TRequest, TResult>(string clientApi, string url,
            CancellationToken cancellationToken,
            MethodType method = MethodType.Get,
            TRequest requestEntity = null)
            where TResult : class where TRequest : class;
    }
}