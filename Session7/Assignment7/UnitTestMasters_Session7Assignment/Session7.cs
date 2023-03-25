using Xunit;

namespace UnitTestMasters_Session7Assignment
{
    public class Tests
    {
        [Fact]
        public void Process_saved_order_and_apply_discount()
        {
            
        }
    }

    public class Order
    {
        public int OrderId { get; private set; }
        public int CustomerId { get; private set; }
        public List<int> ProductIds { get; private set; }
        public decimal TotalPrice { get; private set; }

        public void ProcessOrder(int orderId)
        {
            var order = Database.GetOrderByOrderId(orderId);
            OrderId = orderId;
            CustomerId = order.CustomerId;
            ProductIds = order.ProductIds;
            TotalPrice = order.TotalPrice;

            var customerData = Database.GetCustomerByCustomerId(order.CustomerId);
            LoyaltyLevel loyaltyLevel = (LoyaltyLevel)customerData[0];

            var productDatas = Database.GetProducts(ProductIds);
            decimal totalPrice = 0;
            foreach (var productData in productDatas)
            {
                totalPrice += (decimal)productData[0];
            }

            switch (loyaltyLevel)
            {
                case LoyaltyLevel.Bronze:
                    totalPrice *= 0.70m;
                    break;
                case LoyaltyLevel.Silver:
                    totalPrice *= 0.60m;
                    break;
                case LoyaltyLevel.Gold:
                    totalPrice *= 0.50m;
                    break;
            }

            order.TotalPrice = totalPrice;


            Database.SaveOrder(order);

            MessageBus.SendOrderProcessedMessage(orderId);
        }
    }

    public enum LoyaltyLevel
    {
        Bronze,
        Silver,
        Gold
    }

    public class Database
    {
        public static Order GetOrderByOrderId(int orderId)
        {
            return null;
        }

        public static object[] GetCustomerByCustomerId(object customerId)
        {
            return null;
        }

        public static List<object[]> GetProducts(List<int> productIds)
        {
            return null;
        }

        public static void SaveOrder(Order order)
        {            
        }
    }

    public class MessageBus
    {
        private static IBus _bus;

        public static void SendOrderProcessedMessage(int orderId)
        {
            _bus.Send($"Subject: ORDER; Type: Order Processed; Id: {orderId};");
        }
    }

    internal interface IBus
    {
        void Send(string message);
    }
}