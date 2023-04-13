using Moq;
using UnitTestMasters_Session7Assignment.Models;
using UnitTestMasters_Session7Assignment.Repositoty;
using UnitTestMasters_Session7Assignment.Utility;
using Xunit;

namespace UnitTestMasters_Session7Assignment.Services.Tests
{
    public class OrderServiceTests
    {
        private Mock<IOrderRepository> _mockOrderRepository;
        private Mock<IBus> _mockBus;
        private Mock<MessageBus> _mockMessageBus;
        private OrderService _orderService;

        public OrderServiceTests()
        {
            _mockOrderRepository = new Mock<IOrderRepository>();
            _mockBus = new Mock<IBus>();
            _mockMessageBus = new Mock<MessageBus>(_mockBus.Object);
            _orderService = new OrderService(_mockOrderRepository.Object, _mockMessageBus.Object);
        }

        [Fact()]
        public void Process_saved_order_and_apply_discount()
        {
            //Calculate saved order of orderId 1 with discounted total price 300 (GOLD)

            // Arrange
            decimal expectedTotalPrice = 300;
            int orderId = 1;
            var order = new Order(1, 1, new List<int> { 1, 2, 3 });
            var customer = new Customer(1, LoyaltyLevel.Gold);
            var products = new List<Product>()
            {
                new Product(1,100),
                new Product(2,200),
                new Product(3,300),
            };

            string msg = $"Subject: ORDER; Type: Order Processed; Id: {orderId};";
            _mockOrderRepository.Setup(x => x.GetOrderByOrderId(orderId)).Returns(order);
            _mockOrderRepository.Setup(x => x.GetCustomerByCustomerId(order.CustomerId)).Returns(customer);
            _mockOrderRepository.Setup(x => x.GetProducts(order.ProductIds)).Returns(products);

            // Act
            _orderService.ProcessOrder(orderId);

            // Assert 
            Assert.Equal(expectedTotalPrice, order.TotalPrice);
            _mockOrderRepository.Verify(s => s.SaveOrder(order), Times.Once);
            _mockBus.Verify(s => s.Send(msg), Times.Once);
        }
    }
}