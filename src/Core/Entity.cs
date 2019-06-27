using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public abstract class Entity
    {
        private List<IDomainEvent> _domainEvents;
        public IEnumerable<IDomainEvent> DomainEvents => _domainEvents;

        public Entity()
        {
            _domainEvents = new List<IDomainEvent>();
        }

        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}
