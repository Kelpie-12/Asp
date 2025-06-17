using MVC.Data.Models;
using MVC.Model.DTO;

namespace MVC.Services
{
    public interface IReviewServices
    {
        List<Review> GetReviewsForProduct(Product product);
        void CreateReview(User user, Product product, ReviewDTO reviewDTO);
    }
}
