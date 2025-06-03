using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MVC.Model;
using MVC.Services;
using MVC.Services.Implementation;

namespace MVC.Controllers
{
    [Route("Calc")]
    public class CalcController : Controller
    {
        //private readonly ICalcServices _calcServices;
        //public CalcController(ICalcServices calcServices)
        //{
        //    _calcServices = calcServices;
        //}
        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            return View(new Calculator());
        }
        [HttpPost]
        [Route("Index")]
        public IActionResult Index([FromServices] ICalcServices _calcServices, Calculator c, string calculate)
        {
            //ICalcServices _calcServices = HttpContext.RequestServices.GetService<ICalcServices>();

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
