using System.ComponentModel.DataAnnotations;
using System.Reflection.PortableExecutable;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoWeb.Models;
using ToDoWeb.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ToDoWeb.Pages.Tasks
{
    public class NewTaskModel : PageModel
    {
        private readonly ITaskServices _taskService;

        [BindProperty, Required(ErrorMessage = "Слишком короткое название"), MinLength(3), MaxLength(10)]
        public string? Title { get; set; }
        [BindProperty]
        public string? Description { get; set; }
        [BindProperty]
        public DateTime? DateTime { get; set; }
        [BindProperty(SupportsGet = true)]
        public long? Id { get; set; }
        public string? ErroyMessage { get; set; }
        public NewTaskModel(ITaskServices taskService)
        {

            _taskService = taskService;
        }

        public void OnGet()
        {
            if (Id != null)
            {
                Console.WriteLine(Id);
                UserTask tmp = _taskService.GetUserTask((long)Id);
                Title = tmp.Header;
                Description = tmp.Desc;
                DateTime = tmp.Date;
            }
        }
        public IActionResult OnPostCreate()
        {
            CreateTask();
            return RedirectToPage("/Tasks/Index");
            // Console.WriteLine(Request.Form["title"]);

        }
        public IActionResult OnPostEdit()
        {
            UserTask tmp = new UserTask()
            {
                Header = Title,
                Date = DateTime,
                Desc = Description,
                Id = (long)this.Id
            };
            _taskService.EditTask(tmp);
            return RedirectToPage("/Tasks/Index");
            // Console.WriteLine(Request.Form["title"]);
        }

        private void CreateTask()
        {
            if (!ModelState.IsValid)
            {
                ErroyMessage = "Слишком мало символов";
                return;
            }
            //string? title = Request.Form["title"];
            //string? description = Request.Form["description"];
            //DateTime date = Convert.ToDateTime(Request.Form["datetime"]);          
            _taskService.CreateTask(Title, Description, DateTime.Value);

        }
    }
}
