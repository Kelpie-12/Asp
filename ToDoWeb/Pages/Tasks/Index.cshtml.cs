using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoWeb.Services;
using ToDoWeb.Models;
using System.IO;

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
        public void OnPost()
        {
            // RedirectToPage("/Tasks/NewTask");
        }
        public IActionResult OnPostEdit(long id)
        {
            
            return Redirect($"/Tasks/NewTask/{id}");
            //Console.WriteLine($"/Tasks/NewTask/{id}");
            //return RedirectToPage($"/Tasks/NewTask/{id}");
        }
        public void OnPostDelete(long id)
        {
            Console.WriteLine($"{id} - > delete");
            System.IO.File.Delete($"../ToDoWeb/Pages/Tasks/JsonTask/{id}.json");
            TaskService.DeleteTask(id);
        }
    }
}
