using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MVC.Model;
using MVC.Services;

namespace MVC.Controllers
{
    public class CalcController : Controller
    {
        private readonly ICalcServices _calcServices;
        public CalcController(ICalcServices calcServices)
        {
            _calcServices = calcServices;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(new Calculator());
        }
        [HttpPost]
        public IActionResult Index(Calculator c, string calculate)
        {

            if (calculate == "add")
            {
                _calcServices.Sum(c);
            }
            else if (calculate == "min")
            {
                _calcServices.Minus(c);
            }
            else if (calculate == "mul")
            {
                _calcServices.Multi(c);
            }
            else if (calculate == "div")
            {
                _calcServices.Division(c);
               
            }
            return View(c);
        }
    }
}
