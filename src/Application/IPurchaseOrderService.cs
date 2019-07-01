using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public interface IPurchaseOrderService
    {
        IEnumerable<PurchaseOrderDto> GetAllPurchaseOrders();
    }
}
