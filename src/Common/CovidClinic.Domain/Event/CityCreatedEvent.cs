using CovidClinic.Domain.Common;
using CovidClinic.Domain.Entities;

namespace CovidClinic.Domain.Event
{
    public class CityCreatedEvent : DomainEvent
    {
        public CityCreatedEvent(City city)
        {
            City = city;
        }

        public City City { get; }
    }
}
