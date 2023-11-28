using ShoppingApp1.Models;
using ShoppingApp1.Models;

namespace ShoppingApp1.Interfaces
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product Add(Product product);
    }
}
