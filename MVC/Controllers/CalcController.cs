using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MVC.Controllers
{
    public class CalcController:Controller
    {
        public string Sum(int a,int b)
        {
            int sum = a + b;
            return "" + sum;
        }
        public IActionResult Index()
        {
            return View("Index"); 
        }
    }
}
