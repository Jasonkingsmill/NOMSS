using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class QuantityOnHandBelowReorderThresholdEvent : IDomainEvent
    {
        public QuantityOnHandBelowReorderThresholdEvent(int productId, int reorderAmount)
        {
            ProductId = productId;
            ReorderAmount = reorderAmount;
        }

        public int ProductId { get; }
        public int ReorderAmount { get; }
    }
}
