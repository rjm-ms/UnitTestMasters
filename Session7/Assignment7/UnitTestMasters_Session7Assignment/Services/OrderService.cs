using UnitTestMasters_Session7Assignment.Repositoty;
using UnitTestMasters_Session7Assignment.Utility;

namespace UnitTestMasters_Session7Assignment.Services
{
    /// <summary>
    /// This is Application Service Layer in this context
    /// </summary>
    public class OrderService : IOrderService
    {
        IOrderRepository _orderRepo;
        MessageBus _messageBus;

        public OrderService(IOrderRepository  orderRepo, MessageBus messageBus)
        {
            _orderRepo = orderRepo;
            _messageBus = messageBus;
        }

        public void ProcessOrder(int orderId)
        {
            var order = _orderRepo.GetOrderByOrderId(orderId);
            var customer = _orderRepo.GetCustomerByCustomerId(order.CustomerId);
            var products = _orderRepo.GetProducts(order.ProductIds);

            order.SetTotalPrice(customer.LoyaltyLevel, products);

            _orderRepo.SaveOrder(order);
            _messageBus.SendOrderProcessedMessage(orderId);
        }
    }
}