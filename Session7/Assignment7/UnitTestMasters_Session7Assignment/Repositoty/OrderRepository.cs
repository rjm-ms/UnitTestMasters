using UnitTestMasters_Session7Assignment.Models;

namespace UnitTestMasters_Session7Assignment.Repositoty
{
    public class OrderRepository : IOrderRepository
    {
        public Order GetOrderByOrderId(int orderId)
        {
            var order = DB.Orders.Where(x => x.OrderId == orderId)
                .FirstOrDefault();

            return order;
        }

        public Customer GetCustomerByCustomerId(int customerId)
        {
            var customer = DB.Customers.Where(x => x.CustomerId == customerId)
                .FirstOrDefault();

            return customer;
        }

        public List<Product> GetProducts(List<int> productIds)
        {
            var products = new List<Product>();

            foreach (var item in productIds)
            {
                var product = DB.Products.Where(x => x.ProductId == item)
                .FirstOrDefault();

                if (product != null)
                    products.Add(product);
            }
            return products;
        }

        public void SaveOrder(Order order)
        {
            if (GetOrderByOrderId(order.OrderId) != null)
            {
                var indexOf = DB.Orders.IndexOf(DB.Orders.Find(p => p.OrderId == order.OrderId));
                DB.Orders[indexOf] = order;
            }
            else
            {
                DB.Orders.Add(order);
            }
        }
    }
}