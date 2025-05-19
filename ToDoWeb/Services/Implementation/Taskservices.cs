using ToDoWeb.Models;

namespace ToDoWeb.Services.Implementation
{
    public class TaskServices : ITaskServices
    {
        private readonly List<UserTask> _tasks = new List<UserTask>()
        {
            new UserTask { Header = "Задача 1", Desc = "", Date = new DateTime(2025, 05, 14) },
            new UserTask { Header = "Задача 2", Desc = "", Date = new DateTime(2025, 05, 10) }
        };
        public void CreateTask(string title, string desc, DateTime date)
        {
            UserTask task = new UserTask() { Header = title, Date = date, Desc = desc };
            _tasks.Add(task);
        }

        public List<UserTask> GetAllUserTasks()
        {
            return _tasks;

        }
    }
}
