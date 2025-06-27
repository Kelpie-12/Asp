using API.Data.Model;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskServices _taskService;
        public TaskController(ITaskServices taskService)
        {
            _taskService = taskService;
        }
        [HttpGet]
        [Route("GetAll")]
        public List<UserTask> GetTasks()
        {
            return _taskService.GetAll();
        }
        [HttpPut]
        [Route("CreateTask")]
        public void CreateNewTask(string title, string desc)
        {
            _taskService.AddTask(new UserTask() { Title = title, Desc = desc });
        }
        [HttpDelete]
        [Route("DeleteTask")]
        public void DeleteTask(long id)
        {
            _taskService.DeleteTask(id);
        }
     
    }
}
