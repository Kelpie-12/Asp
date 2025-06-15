using MVC.Data.Models;

namespace MVC.Services
{
    public interface IReviewServices
    {
        List<Review> GetReviewsForProduct(Product product);
        bool AddNewReview(Review review);
    }
}
