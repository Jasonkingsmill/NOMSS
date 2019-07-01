using Core;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Events
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public DomainEventDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Dispatch(IDomainEvent domainEvent)
        {
            using (var scope = _serviceProvider.CreateScope())
            {

                var eventType = domainEvent.GetType();
                var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(eventType);

                var handlers = scope.ServiceProvider.GetServices(handlerType);

                if (handlers == null)
                    return;

                foreach (dynamic handler in handlers as Array)
                {
                    try
                    {
                        handler.Handle((dynamic)domainEvent);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }
    }
}
