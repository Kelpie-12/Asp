using Microsoft.AspNetCore.Mvc;
using MVC.Model.Veiw;
using MVC.Services;
using MVC.Services.Implementation;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVC.Controllers
{
    [Route("{controller}")]
    public class HomeController : Controller
    {
        private readonly IWelcomeServices _welcomeMessage;
        public HomeController(IWelcomeServices welcomeMessage)
        {
            _welcomeMessage = welcomeMessage;
        }
        [HttpGet]
        //[ActionName("Index")]
        [Route("/")]
        public IActionResult Index([FromServices] IProductServices productService)
        {
            HomePageViewModel model = new HomePageViewModel()
            {
                Products = productService.GetProducts()
            };

            return View(model);
        }
        [HttpGet]
        public void Welcome()
        {
            Console.WriteLine($"{_welcomeMessage.GetMessage()}");
        }
        public void Time()
        {
            string date =
                System.String.Format("{0:00}.{1:00}.{2:0000}",
                DateTime.Now.Day,
                DateTime.Now.Month,
                DateTime.Now.Year);
            string time = System.String.Format("{0:00}:{1:00}:{2:00}",
                DateTime.Now.TimeOfDay.Hours,
                DateTime.Now.TimeOfDay.Minutes,
                DateTime.Now.TimeOfDay.Seconds);
            Console.WriteLine($"Дата {date}\nВремя {time}");

        }
    }
}
