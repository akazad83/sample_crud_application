using System.Threading.Tasks;
using CovidClinic.Domain.Common;

namespace CovidClinic.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
