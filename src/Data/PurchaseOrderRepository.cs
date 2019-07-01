using Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private List<PurchaseOrder> _purchaseOrders;


        public PurchaseOrderRepository(List<PurchaseOrder> purchaseOrders = null)
        {
            _purchaseOrders = purchaseOrders ?? new List<PurchaseOrder>();
        }

        public void Add(PurchaseOrder purchaseOrder)
        {
            _purchaseOrders.Add(purchaseOrder);
        }

        public IEnumerable<PurchaseOrder> GetAll()
        {
            return _purchaseOrders.ToList();
        }



    }
}
