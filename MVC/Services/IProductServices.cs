using MVC.Model.Domain;

namespace MVC.Services
{
    public interface IProductServices
    {
        List<Product> GetProducts();
        Product? GetProductById(int id);
    }
}
