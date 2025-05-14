using ToDoWeb.Models;

namespace ToDoWeb.Services.Implementation
{
    public class TaskServices : ITaskServices
    {
        public List<UserTask> GetAllUserTasks()
        {
            return new List<UserTask>() 
            {
                new UserTask { Header = "Задача 1", Desc = "", Date = new DateTime(2025, 05, 14) },
                new UserTask { Header = "Задача 2", Desc = "", Date = new DateTime(2025, 05, 10) }
            };

        }
    }
}
