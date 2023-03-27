using UnitTestMasters_Session7Assignment.Models;

namespace UnitTestMasters_Session7Assignment.Repositoty
{
    public class DB
    {
        public static List<Order> Orders = new List<Order>()
        {
            new Order(1,1,new List<int>{1,2,3}),
            new Order(2,1,new List<int>{1,2,3}),
            new Order(3,3,new List<int>{1,2,3}),
            new Order(4,2,new List<int>{1,2,3}),
            new Order(4,2,new List<int>{1,2,3}),
            new Order(5,1,new List<int>{1,2,3}),
        };

        public static List<Product> Products = new List<Product>()
        {
            new Product(1,100),
            new Product(2,200),
            new Product(3,300),
        };

        public static List<Customer> Customers = new List<Customer>()
        {
            new Customer(1, LoyaltyLevel.Silver),
            new Customer(2, LoyaltyLevel.Bronze),
            new Customer(3, LoyaltyLevel.Gold),
        };
    }
}