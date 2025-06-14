using MVC.Data;
using MVC.Data.Models;

namespace MVC.Services.Implementation
{
    public class ReviewServices : IReviewServices
    {
        private readonly ApplicationDbContext _database;

        public ReviewServices(ApplicationDbContext database)
        {
            _database = database;
        }
        public List<Review> GetReviewsForProduct(Product product)
        {
            return _database.Reviews
                .Where(review => review.ProductId == product.Id)
                .ToList();
        }
    }
}
