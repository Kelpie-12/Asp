using Microsoft.AspNetCore.Mvc;
using MVC.Data.Models;
using MVC.Services;

namespace MVC.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewServices _reviewServices;
        private readonly IProductServices _productService;
        public Review Review { get; set; }
        public ReviewController(IReviewServices reviewServices, IProductServices productService)
        {
            _reviewServices = reviewServices;
            _productService = productService;
        }
        [HttpGet]
        [Route("{controller}/{action}/{id:int?}")]
        public IActionResult Index(int id)
        {
            Console.WriteLine("ReviewController");
            Product product = _productService.GetProductById(id);
            Review = new Review()
            {
                Author = " ",
                Product = product,
                ProductId = id,
                Text = " ",
                Id = 1,
                Rating = 1,
                CreateAt = DateTime.Now
            };

            return View(Review);
        }
        [HttpPost]
        [Route("{controller}/{action}/{id:int?}")]
        public IActionResult AddNewReview(Review review)
        {
            _reviewServices.AddNewReview(review);
            return View("Index");
        }
    }
}
