using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IPurchaseOrderRepository
    {
        IEnumerable<PurchaseOrder> GetAll();
        void Add(PurchaseOrder purchaseOrder);
    }
}
