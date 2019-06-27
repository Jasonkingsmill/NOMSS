using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public class OrderItem
    {
        private OrderItem() { }
        public OrderItem(int productId, int quantity, decimal costPerItem)
        {
            ProductId = productId;
            Quantity = quantity;
            CostPerItem = costPerItem;
        }

        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Decimal CostPerItem { get; set; }
    }
}
