using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restoran.Models;
using Restoran.Services;

namespace Restoran.Pages
{
    public class AdressModel : PageModel
    {
        private readonly ILogger<AdressModel> _logger;
        private readonly IRestorauntServices _restorauntService;
        public List<Restaurant> Restaurants { get; private set; }
        
        public AdressModel(ILogger<AdressModel> logger, IRestorauntServices restorauntService)
        {
            _restorauntService = restorauntService;
            _logger = logger;
        }
        public void OnGet()
        {
            _logger.LogInformation("Ползователь зашел на страницу адрессов");
            Restaurants = _restorauntService.GetRestaurants();
            
            // Console.WriteLine("Ползователь зашел на страницу адрессов");
        }
    }
}
