using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Events
{
    public interface IDomainEventHandler<T> where T : IDomainEvent
    {
        void Handle(T @event);
    }
}
