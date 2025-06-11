using MVC.Model.Domain;

namespace MVC.Data.Repositories
{
    public interface IUserReviewRepository
    {
        List<UserReview> GetUserReviewsById(long id);
    }
}
