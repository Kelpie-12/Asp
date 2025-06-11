using MVC.Data.Repositories;
using MVC.Model.Domain;

namespace MVC.Services.Implementation
{
    public class ProductServices : IProductServices
    {
        private readonly List<Product> products = new List<Product>() { };
        private readonly IproductRepository _productRepository;
        //private readonly ISqlDbServices _sqlDbServices;
        //private readonly IJsonDbServices _jsonDbServices;

        public ProductServices(/*ISqlDbServices sqlDbServices,*/ IproductRepository productRepository)
        {
            //_sqlDbServices = sqlDbServices;
            _productRepository = productRepository;
            products = _productRepository.GetAll();
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
