using Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;

namespace UnitTests
{
    public class Order_Tests
    {
        public class Fulfill : Order_Tests
        {
            private Mock<IProductRepository> _productRepository;
            private OrderProcessingService _orderProcessingService;

            public Fulfill()
            {

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
                _orderProcessingService = new OrderProcessingService(_productRepository.Object);


                // Act
                _orderProcessingService.ProcessOrder(order);


                // Assert
                Assert.Equal(OrderStatus.Fulfilled, order.Status);
                Assert.Equal(quantityOnHand - orderQuantity, product.QuantityOnHand);
            }
        }
    }
}
