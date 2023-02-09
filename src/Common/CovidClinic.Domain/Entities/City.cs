using System.Collections.Generic;
using CovidClinic.Domain.Common;
using CovidClinic.Domain.Event;

namespace CovidClinic.Domain.Entities
{
    public class City : AuditableEntity, IHasDomainEvent
    {
        public City()
        {
            DomainEvents= new List<DomainEvent>();
        }

        public int Id { get; set; }

        public int Rank { get; set; }

        public string Name { get; set; }

        public int Population { get; set; }

        private bool _active;

        public bool Active
        {
            get => _active;
            set
            {
                if (value && _active == false)
                {
                    DomainEvents.Add(new CityActivatedEvent(this));
                }

                _active = value;
            }
        }

        public List<DomainEvent> DomainEvents { get; set; }
    }
}
