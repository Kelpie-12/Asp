using MVC.Data.Repositories;
using MVC.Model.Domain;
using MVC.Model.Veiw;

namespace MVC.Services.Implementation
{
    public class ProductServices : IProductServices
    {
        private readonly List<Product> products = new List<Product>() { };
        private readonly IproductRepository _productRepository;
       

        public ProductServices( IproductRepository productRepository)
        {          
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

        public HomePageViewModel<Product> GetProducts(int page)
        {
            return _productRepository.GetAll(page);
        }
    }
}
