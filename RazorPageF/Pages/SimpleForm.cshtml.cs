using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageF.Pages
{
    public class SimpleFormModel : PageModel
    {
        private readonly ILogger<SimpleFormModel> _logger;
        public SimpleFormModel(ILogger<SimpleFormModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            _logger.LogInformation(Request.Form["Login"]);
            string login = Request.Form["Login"];
            return RedirectToPage("SimpleForm");
        }
    }
}
