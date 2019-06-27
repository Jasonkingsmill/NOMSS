using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Product
    {
        public Product(int productId, string description, int quantityOnHand, int reorderThreshold, int reorderAmount, int deliveryLeadTime)
        {
            ProductId = productId;
            Description = description;
            QuantityOnHand = quantityOnHand;
            ReorderThreshold = reorderThreshold;
            ReorderAmount = reorderAmount;
            DeliveryLeadTime = deliveryLeadTime;
        }

        public int ProductId { get; private set; }

        public bool IsStockAvailable(int quantity)
        {
            return QuantityOnHand >= quantity;
        }

        public string Description { get; private set; }
        public int QuantityOnHand { get; private set; }
        public int ReorderThreshold { get; private set; }
        public int ReorderAmount { get; private set; }
        public int DeliveryLeadTime { get; private set; }

        public void ReduceQuantityOnHand(int amount)
        {
            if (QuantityOnHand - amount < 0)
                throw new InvalidOperationException("Cannot reduce quantity on hand below 0");
            
            QuantityOnHand = QuantityOnHand - amount;
        }

  
    }

}
