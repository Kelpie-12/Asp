using MVC.Model.Domain;

namespace MVC.Services.Implementation
{
    public class ProductServices : IProductServices
    {
        private readonly List<Product> products = new List<Product>()
        {
            new Product() { Id = 0, Name = "Product 1"  },
            new Product() { Id = 1, Name = "Product 2" },
            new Product() { Id = 2, Name = "Product 3" }
        };
        private readonly IJsonDbServices _jsonDbServices;
        public ProductServices(IJsonDbServices jsonDbServices)
        {
            _jsonDbServices = jsonDbServices;
            foreach(var item in products)
            {
                item.UserReviews = _jsonDbServices.GetUserReviewToJSONById(item.Id);
            }
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
