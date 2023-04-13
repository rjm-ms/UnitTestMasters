namespace UnitTestMasters_Session7Assignment.Models
{
    public class Customer
    {
        public Customer(int customerId, LoyaltyLevel loyaltyLevel)
        {
            CustomerId = customerId;
            LoyaltyLevel = loyaltyLevel;
        }
        public int CustomerId { get; private set; }
        public LoyaltyLevel LoyaltyLevel { get; private set; }
    }
}