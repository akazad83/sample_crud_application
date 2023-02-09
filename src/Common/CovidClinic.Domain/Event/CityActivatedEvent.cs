using CovidClinic.Domain.Common;
using CovidClinic.Domain.Entities;

namespace CovidClinic.Domain.Event
{
    public class CityActivatedEvent : DomainEvent
    {
        public CityActivatedEvent(City city)
        {
            City = city;
        }

        public City City { get; }
    }
}
