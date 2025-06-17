using Microsoft.AspNetCore.Mvc;
using MVC.Data.Models;
using MVC.Model.Veiw;
using MVC.Services;

namespace MVC.Controllers
{
    [Route("{controller}")]
    public class HomeController : Controller
    {       

        private readonly IProductServices _productServices;
        private readonly IReviewServices _reviewServices;

        public HomeController( IProductServices productServices,IReviewServices reviewServices)
        {
            _productServices = productServices;
            _reviewServices = reviewServices;
        }
        [HttpGet]
        //[ActionName("Index")]
        [Route("/")]
        public IActionResult Index(int page=0)
        {
            page = Math.Clamp(page, 0, int.MaxValue);
            List<Product> model = _productServices.GetProducts();           
            return View(model);
        }        
    }
}
