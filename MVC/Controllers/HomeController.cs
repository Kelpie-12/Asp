using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MVC.Data.Repositories;
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
        private readonly IproductRepository _iproductRepository;
      
        public HomeController(IWelcomeServices welcomeMessage, IproductRepository iproductRepository)
        {
            _welcomeMessage = welcomeMessage;
            _iproductRepository = iproductRepository;
           
        }
        [HttpGet]
        //[ActionName("Index")]
        [Route("/")]
        public IActionResult Index()
        {
            HomePageViewModel model = new HomePageViewModel()
            {
                Products = _iproductRepository.GetAll()
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
