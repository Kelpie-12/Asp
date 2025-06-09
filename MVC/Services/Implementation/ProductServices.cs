using MVC.Model.Domain;

namespace MVC.Services.Implementation
{
    public class ProductServices : IProductServices
    {
        private readonly List<Product> products = new List<Product>() { };
        private readonly ISqlDbServices _sqlDbServices;
        //private readonly IJsonDbServices _jsonDbServices;

        public ProductServices(ISqlDbServices sqlDbServices)
        {
            _sqlDbServices = sqlDbServices;
            products = sqlDbServices.GetAllProducts();
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public Product? GetProductById(int id)
        {
            foreach (Product product in products)
            {
                if (product.Id == id)
                    return product;
            }

            return null;
        }
    }
}
