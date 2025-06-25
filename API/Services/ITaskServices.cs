using API.Data.Model;

namespace API.Services
{
    public interface ITaskServices
    {
        void AddTask(UserTask task);
        UserTask GetUserTaskByName(string title);
        List<UserTask> GetAll();
        void DeleteTask(long id);
    }
}
