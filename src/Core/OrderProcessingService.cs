using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class OrderProcessingService
    {
        private readonly IProductRepository _productRepository;

        public OrderProcessingService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void ProcessOrder(Order order)
        {
            foreach (var orderItem in order.Items)
            {
                var product = _productRepository.GetById(orderItem.ProductId);
                try
                {
                    product.ReduceQuantityOnHand(orderItem.Quantity);
                }
                catch (InvalidOperationException)
                {
                    order.ChangeStatus(OrderStatus.Error_Unfulfillable);
                    throw;
                }
            }
            order.ChangeStatus(OrderStatus.Fulfilled);
        }
    }
}
