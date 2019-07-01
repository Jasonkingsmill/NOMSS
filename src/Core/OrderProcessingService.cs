using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class OrderProcessingService
    {
        private readonly IProductRepository _productRepository;
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;
        private readonly IDomainEventDispatcher _domainEventDispatcher;

        public OrderProcessingService(IProductRepository productRepository, IPurchaseOrderRepository purchaseOrderRepository, IDomainEventDispatcher domainEventDispatcher)
        {
            _productRepository = productRepository;
            _purchaseOrderRepository = purchaseOrderRepository;
            _domainEventDispatcher = domainEventDispatcher;
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

                product.ReduceQuantityOnHand(_domainEventDispatcher, orderItem.Quantity);
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
