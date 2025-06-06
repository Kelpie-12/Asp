using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using MVC.Model.Domain;

namespace MVC.Services.Implementation
{
    public class ReviewServices : IReviewService
    {
        private readonly IJsonDbServices _jsonDbServices;        
        public ReviewServices(IJsonDbServices jsonDbServices)
        {
            _jsonDbServices = jsonDbServices;
        }
        public bool AddNewUserReview(UserReview review)
        {
            return _jsonDbServices.AddNewUserReviewToJSON(review);
        }

        public bool DeleteUserReview(UserReview review)
        {
            return _jsonDbServices.DeleteUserReviewToJSON(review);
        }

        public bool EditUserReview(UserReview review)
        {
            return _jsonDbServices.EditUserReviewToJSON(review);
        }

        public List<UserReview> GetAllUserReviews()
        {
            return _jsonDbServices.GetUserReviewToJSON();
        }

        public List<UserReview> GetAllUserReviewsByIdProduct(int id)
        {
            return _jsonDbServices.GetUserReviewToJSONById(id);
        }
    }
}
