using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IDomainEventDispatcher
    {
        void Dispatch(IDomainEvent domainEvent);
    }
}
