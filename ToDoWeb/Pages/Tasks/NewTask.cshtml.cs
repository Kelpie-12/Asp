using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoWeb.Services;

namespace ToDoWeb.Pages.Tasks
{
    public class NewTaskModel : PageModel
    {
        private readonly ITaskServices _taskService;

        public NewTaskModel(ITaskServices taskService)
        {
            _taskService = taskService;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            CreateTask();
            return RedirectToPage("/Tasks/Index");
            // Console.WriteLine(Request.Form["title"]);

        }      

        private void CreateTask()
        {
            string? title = Request.Form["title"];
            string? description = Request.Form["description"];
            DateTime date = Convert.ToDateTime(Request.Form["datetime"]);
            _taskService.CreateTask(title, description, date);

        }
    }
}
