using Microsoft.AspNetCore.Mvc;
using MVC.Model;
using MVC.Services;
using MVC.Services.Implementation;
namespace MVC.Controllers
{
    public class ReviewController : Controller
    {     
        [HttpGet]
        public IActionResult Index([FromServices] IReviewService reviewService)
        {             
            return View("Index", reviewService.GetAllUserReviews());
        }
        public IActionResult NewReview()
        {
            return View("NewReview");
        }
        [HttpPost]
        public IActionResult AddNewReview([FromServices] IReviewService reviewService, UserReview tmp)
        {
            if (tmp.Desc== string.Empty || tmp.UserName==string.Empty)
            {
                return StatusCode(400);
            }
            reviewService.AddNewUserReview(tmp);
            return View("Index", reviewService.GetAllUserReviews());
        }
    }
}
