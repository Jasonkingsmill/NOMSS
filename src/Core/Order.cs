using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{

    public class Order
    {
        public int OrderId { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateCreated { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }
    }

  

}
