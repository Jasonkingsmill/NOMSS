using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class PurchaseOrder
    {
        public PurchaseOrder(int productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }

        public int ProductId { get; }
        public int Quantity { get; }
    }
}
