using MVC.Model.Domain;

namespace MVC.Services
{
    public interface IReviewService
    {
        List<UserReview> GetAllUserReviews();
        List<UserReview> GetAllUserReviewsByIdProduct(int id);
        bool AddNewUserReview(UserReview review);
        bool DeleteUserReview(UserReview review);
        bool EditUserReview(UserReview review);

    }
}
