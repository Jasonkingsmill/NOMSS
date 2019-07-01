using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;

        public PurchaseOrderService(IPurchaseOrderRepository purchaseOrderRepository)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
        }

        public IEnumerable<PurchaseOrderDto> GetAllPurchaseOrders()
        {
            var pos = _purchaseOrderRepository.GetAll();
            return pos.Select(po => new PurchaseOrderDto() { ProductId = po.ProductId, Quantity = po.Quantity });
        }
    }
}
