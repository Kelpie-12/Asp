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

        public bool AddNewReview(Review review)
        {
            _database.Add(review);
            if (_database.SaveChanges() > 0)
                return true;
            else return false;
          
        }

        public List<Review> GetReviewsForProduct(Product product)
        {
            return _database.Reviews
                .Where(review => review.ProductId == product.Id)
                .ToList();
        }
    }
}
