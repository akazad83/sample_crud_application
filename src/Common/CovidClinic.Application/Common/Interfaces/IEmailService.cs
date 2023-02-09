using System.Threading.Tasks;
using CovidClinic.Application.Common.Models;

namespace CovidClinic.Application.Common.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}
