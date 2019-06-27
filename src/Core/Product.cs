using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Product
    {
        public int ProductId { get; set; }
        public string description { get; set; }
        public int QuantityOnHand { get; set; }
        public int ReorderThreshold { get; set; }
        public int ReorderAmount { get; set; }
        public int DeliveryLeadTime { get; set; }
    }

}
