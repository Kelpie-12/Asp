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

        public HomeController( IProductServices productServices)
        {
            _productServices = productServices;
        }
        [HttpGet]
        //[ActionName("Index")]
        [Route("/")]
        public IActionResult Index(int page=0)
        {
            page = Math.Clamp(page, 0, int.MaxValue);
            HomePageViewModel<Product> model = _productServices.GetProducts(page);
            return View(model);
        }        
    }
}
