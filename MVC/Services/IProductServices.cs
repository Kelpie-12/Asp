using MVC.Data.Models;
using MVC.Model.Veiw;

namespace MVC.Services
{
    public interface IProductServices
    {
        List<Product> GetProducts();
        List<Product> GetProducts(int page);
        Product? GetProductById(long id);
    }
}
