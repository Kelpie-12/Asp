using MVC.Data.Models;
using MVC.Model.Veiw;
using MVC.Data;

namespace MVC.Services.Implementation
{
    public class ProductServices : IProductServices
    {
        private readonly ApplicationDbContext _database;
        private const int PRODUCTS_PER_PAGE = 10;

        public ProductServices(ApplicationDbContext database)
        {
            _database = database;
        }

        public List<Review> GetReviewsForProduct(Product product)
        {
            return _database.Reviews.Where(review => review.ProductId == product.Id).ToList();
        }
        public List<Product> GetProducts()
        {
            return _database.Products.ToList();
        }

        public Product? GetProductById(long id)
        {
            return _database.Products.Find(id);
        }

        public List<Product> GetProducts(int page)
        {
           // double productCount = _database.Products.Count() / PRODUCTS_PER_PAGE;

            //HomePageViewModel<Product> p = new HomePageViewModel<Product>()
            //{
            //    CurrentPage = page,
            //    MaxPage = (int)Math.Ceiling(productCount),
           // Products = _database.Products.ToList();
                //_database.Products.Skip(PRODUCTS_PER_PAGE*page).Take(PRODUCTS_PER_PAGE).ToList()
           // };
            return _database.Products.ToList();
        }
    }
}
