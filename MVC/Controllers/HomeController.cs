using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
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
        private readonly ISqlDbServices _sqlDbServices;
        //private readonly IConfiguration _configuration;
        public HomeController(IWelcomeServices welcomeMessage, ISqlDbServices sqlDbServices/*, IConfiguration configuration*/)
        {
            _welcomeMessage = welcomeMessage;
            _sqlDbServices = sqlDbServices;
            //_configuration = configuration;
        }
        [HttpGet]
        //[ActionName("Index")]
        [Route("/")]
        public IActionResult Index(/*[FromServices] IProductServices productService*/)
        {
            HomePageViewModel model = new HomePageViewModel()
            {
                Products = _sqlDbServices.GetAllProducts(/*_configuration*/)
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
