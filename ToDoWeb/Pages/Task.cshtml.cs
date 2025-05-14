using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoWeb.Models;
using ToDoWeb.Services;

namespace ToDoWeb.Pages
{
    public class TaskModel : PageModel
    {
        private readonly ITaskServices _taskServices;
        public List<UserTask> Tasks { get; set; }
        public TaskModel(ITaskServices taskServices)
        {
            _taskServices = taskServices;
        }
        public void OnGet()
        {
            Tasks = _taskServices.GetAllUserTasks();
        }
    }
}
