using MVC.Model;

namespace MVC.Services
{
    public interface IReviewService
    {
        List<UserReview> GetAllUserReviews();
        bool AddNewUserReview(UserReview review);
        bool DeleteUserReview(UserReview review);
        bool EditUserReview(UserReview review);

    }
}
