using Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class OrderRepository : IOrderRepository
    {
        private List<Order> _orders;


        public OrderRepository(List<Order> orders)
        {
            _orders = orders;
        }

        Order IOrderRepository.GetById(int id)
        {
            return _orders.FirstOrDefault(o => o.OrderId == id);
        }


    }
}
