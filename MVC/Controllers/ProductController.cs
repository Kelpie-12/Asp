using Microsoft.AspNetCore.Mvc;
using MVC.Services;
using MVC.Data.Models;
using MVC.Model.Veiw;
using MVC.Model.DTO;

namespace MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices _productService;
        private readonly IReviewServices _reviewServices;


        public ProductController(IProductServices productService, IReviewServices reviewServices)
        {
            _productService = productService;
            _reviewServices = reviewServices;
        }

        [Route("{controller}/{action}/{id:int?}")]
        public IActionResult Index(int? id)
        {

            if (id == null)
                return RedirectToAction("Index", "Home");

            Product? product = _productService.GetProductById((int)id);

            if (product == null)
                return RedirectToAction("Index", "Home");
            List<ReviewDTO> reviews = new List<ReviewDTO>();

            foreach (Review item in _reviewServices.GetReviewsForProduct(product))
            {
                reviews.Add(ReviewDTO.FromEntity(item));
            }
            HomePageViewModel model = new HomePageViewModel()
            {
                Product = product,
                Reviews = reviews

            };

            //product.Reviews = _reviewServices.GetReviewsForProduct(product);

            return View(model);
        }
    }
}
