using Microsoft.AspNetCore.Mvc;
using MVC.Model.Domain;

using MVC.Services;

namespace MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices _productService;
        private readonly IReviewService _reviewService;

        public ProductController(IProductServices productService, IReviewService reviewService)
        {
            _productService = productService;
            _reviewService = reviewService;
        }

        [Route("{controller}/{action}/{id:int?}")]
        public IActionResult Index(int? id)
        {
            if (id == null)
                return RedirectToAction("Index", "Home");

            Product? product = _productService.GetProductById((int)id);
            if (product == null)
                return RedirectToAction("Index", "Home");        

            return View(product);
        }
    }
}
