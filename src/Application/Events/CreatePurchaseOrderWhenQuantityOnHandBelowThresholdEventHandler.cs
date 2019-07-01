using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Events
{
    public class CreatePurchaseOrderWhenQuantityOnHandBelowThresholdEventHandler : IDomainEventHandler<QuantityOnHandBelowReorderThresholdEvent>
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;

        public CreatePurchaseOrderWhenQuantityOnHandBelowThresholdEventHandler(IPurchaseOrderRepository purchaseOrderRepository)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
        }

        public void Handle(QuantityOnHandBelowReorderThresholdEvent @event)
        {
            var po = new PurchaseOrder(@event.ProductId, @event.ReorderAmount);
            _purchaseOrderRepository.Add(po);
        }
    }
}
