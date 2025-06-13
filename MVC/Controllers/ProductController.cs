using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Model.Domain;

using MVC.Services;

namespace MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices _productService;

        public ProductController(IProductServices productService)
        {
            _productService = productService;
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
