using ToDoWeb.Models;

namespace ToDoWeb.Services
{
    public interface ITaskServices
    {
        List<UserTask> GetAllUserTasks();

    }
}
