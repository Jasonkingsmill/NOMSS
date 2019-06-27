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
            if (!CanFulfillOrder(order))
            {
                order.ChangeStatus(OrderStatus.Error_Unfulfillable);
                throw new InvalidOperationException("Cannot fulfill order");
            }

            foreach (var orderItem in order.Items)
            {
                var product = _productRepository.GetById(orderItem.ProductId);

                product.ReduceQuantityOnHand(orderItem.Quantity);
            }
            order.ChangeStatus(OrderStatus.Fulfilled);
        }


        private bool CanFulfillOrder(Order order)
        {
            foreach (var orderItem in order.Items)
            {
                var product = _productRepository.GetById(orderItem.ProductId);

                if (!product.IsStockAvailable(orderItem.Quantity))
                    return false;
            }
            return true;
        }
    }
}
