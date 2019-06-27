using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{

    public class Order
    {
        public Order(IEnumerable<OrderItem> items)
        {
            DateCreated = DateTime.Now;
            Status = OrderStatus.New;
            Items = items;
        }

        [JsonConstructor]
        public Order(int orderId, DateTime dateCreated, OrderStatus status, IEnumerable<OrderItem> items)
        {
            OrderId = orderId;
            DateCreated = dateCreated;
            Status = status;
            Items = items;
        }

        public int OrderId { get; private set; }
        public DateTime DateCreated { get; }
        public OrderStatus Status { get; private set; }
        public IEnumerable<OrderItem> Items { get; private set; }

        public void ChangeStatus(OrderStatus status)
        {
            Status = status;
        }


    }

  

}
