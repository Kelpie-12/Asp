using Microsoft.AspNetCore.Mvc;
using MVC.Model;
using MVC.Services;
namespace MVC.Controllers
{
    public class ReviewController:Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
