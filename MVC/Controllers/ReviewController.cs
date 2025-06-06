using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Model.Domain;
using MVC.Services;
using MVC.Services.Implementation;
namespace MVC.Controllers
{
    [Route("{controller}")]
    public class ReviewController : Controller
    {
        [HttpGet]
        [Route("Index")]
        public IActionResult Index([FromServices] IReviewService reviewService)
        {             
            return View("Index", reviewService.GetAllUserReviews());
        }

        [HttpGet]        
        [Route("NewReview")]
        public IActionResult NewReview()
        {            
            return View("NewReview");
        }

       
        [HttpPost]
        [Route("Index")]
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
