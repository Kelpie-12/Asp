using MVC.Model;

namespace MVC.Services
{
    public interface IJsonDbServices
    {
        public List<UserReview> GetUserReviewToJSON();
        bool AddNewUserReviewToJSON(UserReview review);
        bool DeleteUserReviewToJSON(UserReview review);
        bool EditUserReviewToJSON(UserReview review);
    }
}
