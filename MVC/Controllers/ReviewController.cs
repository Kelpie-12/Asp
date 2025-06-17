using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;
using MVC.Data.Models;
using MVC.Model.DTO;
using MVC.Services;

namespace MVC.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewServices _reviewServices;
        private readonly IProductServices _productService;
        private readonly IUserServices _userService;
        
        public ReviewController(IReviewServices reviewServices, IProductServices productService, IUserServices userService)
        {
            _reviewServices = reviewServices;
            _productService = productService;
            _userService = userService;
        }
        //[HttpGet]
        //[Route("{controller}/{action}/{id:int?}")]
        //public IActionResult Index(int id)
        //{
        //    Console.WriteLine("ReviewController");
        //    Product product = _productService.GetProductById(id);
        //    //Review = new Review()
        //    //{
        //    //    //Author = " ",
        //    //    Product = product,
        //    //    ProductId = id,
        //    //    Text = " ",
        //    //    Id = 1,
        //    //    Rating = 1,
        //    //    CreatedAt = DateTime.Now
        //    //};

        //    return View();
        //}
        [HttpPost]
        [Route("{controller}/{action}/{id:int?}")]
        public IActionResult CreateReview(long productId, ReviewDTO reviewDTO)
        {
            Console.WriteLine("CREATE REVIEW");
            Product? product = _productService.GetProductById(productId);

            if (product == null)
                return BadRequest("Product with specified product id not found");

            User? user = _userService.GetUserById(0);

            if (user == null)
                return Unauthorized("User not found");

            _reviewServices.CreateReview(user, product, reviewDTO);

            return RedirectToAction("Index", "Product", new { id = productId });
        }

        [HttpGet]
        [Route("{controller}/{action}/{id:int?}")]        
        [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]        
        public IActionResult MyReview()
        {
            
            Console.WriteLine("MyReview");
            return Ok();
        }
    }
}
