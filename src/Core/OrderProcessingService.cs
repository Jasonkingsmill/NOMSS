using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class OrderProcessingService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderProcessingService(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public void ProcessOrder(int orderId)
        {
            var order = _orderRepository.GetById(orderId);
            foreach(var orderItem in order.Items)
            {
                var product = _productRepository.GetById(orderItem.ProductId);

            }
        }
    }
}
