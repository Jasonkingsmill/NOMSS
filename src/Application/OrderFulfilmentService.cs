using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class OrderFulfilmentService : IOrderFulfilmentService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly OrderProcessingService _orderProcessingService;

        public OrderFulfilmentService(IOrderRepository orderRepository, OrderProcessingService orderProcessingService)
        {
            _orderRepository = orderRepository;
            _orderProcessingService = orderProcessingService;
        }

        public IEnumerable<int> FulfilOrders(List<int> orderIds)
        {
            List<int> unfulfilledOrders = new List<int>();
            foreach (var orderId in orderIds)
            {
                var order = _orderRepository.GetById(orderId);
                try
                {
                    _orderProcessingService.ProcessOrder(order);
                }
                catch
                {
                    unfulfilledOrders.Add(orderId);
                }
            }
            return unfulfilledOrders;
        }
    }
}
