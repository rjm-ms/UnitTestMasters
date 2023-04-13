namespace UnitTestMasters_Session7Assignment.Models
{
    public class Product
    {
        public Product(int productId, decimal unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
        }
        public int ProductId { get; private set; }
        public decimal UnitPrice { get; private set; }
    }
}