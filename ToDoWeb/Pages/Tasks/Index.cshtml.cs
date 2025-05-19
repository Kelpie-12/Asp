using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoWeb.Services;
using ToDoWeb.Models;

namespace ToDoWeb.Tasks
{
    public class IndexModel : PageModel
    {
        public ITaskServices TaskService { get; private set; }

        public IndexModel(ITaskServices taskService)
        {
            TaskService = taskService;
        }

        public void OnGet()
        {
        }
    }
}
