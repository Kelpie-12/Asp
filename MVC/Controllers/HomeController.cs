using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MVC.Data.Repositories;
using MVC.Model.Domain;
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

        private readonly IProductServices _productServices;

        public HomeController(IWelcomeServices welcomeMessage, IProductServices productServices)
        {
            _welcomeMessage = welcomeMessage;

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
