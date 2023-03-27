namespace UnitTestMasters_Session7Assignment.Models
{
    public class Order
    {
        public Order(int orderId, int customerId, List<int> productIds)
        {
            OrderId = orderId;
            CustomerId = customerId;
            ProductIds = productIds;
        }
        public int OrderId { get; private set; }
        public int CustomerId { get; private set; }
        public List<int> ProductIds { get; private set; }
        public decimal TotalPrice { get; private set; }
        public void SetTotalPrice(LoyaltyLevel loyaltyLevel, List<Product> productDatas)
        {
            decimal totalPrice = 0;
            foreach (var productData in productDatas)
            {
                totalPrice += productData.UnitPrice;
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

            TotalPrice = totalPrice;
        }
    }
}