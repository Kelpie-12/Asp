using MVC.Model.Domain;

namespace MVC.Services
{
    public interface IJsonDbServices
    {
        public List<UserReview> GetUserReviewToJSON();
        public List<UserReview> GetUserReviewToJSONById(long id);
        bool AddNewUserReviewToJSON(UserReview review);
        bool DeleteUserReviewToJSON(UserReview review);
        bool EditUserReviewToJSON(UserReview review);
    }
}
