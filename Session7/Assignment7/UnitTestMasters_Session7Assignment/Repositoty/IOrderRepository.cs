using UnitTestMasters_Session7Assignment.Models;

namespace UnitTestMasters_Session7Assignment.Repositoty
{
    public interface IOrderRepository
    {
        Customer GetCustomerByCustomerId(int customerId);
        Order GetOrderByOrderId(int orderId);
        List<Product> GetProducts(List<int> productIds);
        void SaveOrder(Order order);
    }
}