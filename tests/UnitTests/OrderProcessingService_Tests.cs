 using Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;

namespace UnitTests
{
    public class OrderProcessingService_Tests
    {
        public class ProcessOrder : OrderProcessingService_Tests
        {
            private Mock<IProductRepository> _productRepository;
            private Mock<IPurchaseOrderRepository> _purchaseOrderRepository;
            private Mock<IDomainEventDispatcher> _domainEventDispatcher;
            private OrderProcessingService _orderProcessingService;

            public ProcessOrder()
            {
                _domainEventDispatcher = new Mock<IDomainEventDispatcher>();
            }

            [Fact]
            public void Pending_order_should_be_processed_when_product_included_and_stock_available()
            {
                // Arrange
                var orderId = 9987;
                int productId = 1234;
                int quantityOnHand = 10;
                int orderQuantity = 5;
                decimal costPerItem = 10.00m;
                int reorderThreshold = 5;
                int reorderAmount = 5;

                var orderItem = new OrderItem(productId, orderQuantity, costPerItem);
                var order = new Order(orderId, DateTime.Now, OrderStatus.Pending, new List<OrderItem>()
                {
                    orderItem
                });

                var product = new Product(productId, "test product", quantityOnHand, reorderThreshold, reorderAmount, 10);

                _productRepository = new Mock<IProductRepository>();
                _productRepository.Setup(x => x.GetById(It.Is<int>(p => p == productId))).Returns(product);
                _purchaseOrderRepository = new Mock<IPurchaseOrderRepository>();
                _purchaseOrderRepository.Setup(x => x.Add(It.IsAny<PurchaseOrder>()));

                _orderProcessingService = new OrderProcessingService(_productRepository.Object, _purchaseOrderRepository.Object, _domainEventDispatcher.Object);


                // Act
                _orderProcessingService.ProcessOrder(order);


                // Assert
                Assert.Equal(OrderStatus.Fulfilled, order.Status);
                Assert.Equal(quantityOnHand - orderQuantity, product.QuantityOnHand);
            }




            [Fact]
            public void Pending_order_should_not_be_processed_when_product_included_has_no_stock_available()
            {
                // Arrange
                var orderId = 9987;
                int productId = 1234;
                int quantityOnHand = 4;
                int orderQuantity = 5;
                decimal costPerItem = 10.00m;
                int reorderThreshold = 5;
                int reorderAmount = 5;

                var orderItem = new OrderItem(productId, orderQuantity, costPerItem);
                var order = new Order(orderId, DateTime.Now, OrderStatus.Pending, new List<OrderItem>()
                {
                    orderItem
                });

                var product = new Product(productId, "test product", quantityOnHand, reorderThreshold, reorderAmount, 10);

                _productRepository = new Mock<IProductRepository>();
                _productRepository.Setup(x => x.GetById(It.Is<int>(p => p == productId))).Returns(product);
                _purchaseOrderRepository = new Mock<IPurchaseOrderRepository>();
                _purchaseOrderRepository.Setup(x => x.Add(It.IsAny<PurchaseOrder>()));

                _orderProcessingService = new OrderProcessingService(_productRepository.Object, _purchaseOrderRepository.Object, _domainEventDispatcher.Object);


                // Act
                _orderProcessingService.ProcessOrder(order);


                // Assert
                Assert.Equal(OrderStatus.Error_Unfulfillable, order.Status);
            }


        }
    }
}
