using API.Data;
using API.Data.Model;
using API.Migrations;
using Microsoft.EntityFrameworkCore;

namespace API.Services.Implementation
{
    public class TaskServices : ITaskServices
    {
        ApplicationDbContext _database;
        public TaskServices(ApplicationDbContext database)
        {
            _database = database;
        }
        public void AddTask(UserTask task)
        {
            _database.Tasks.Add(task);
            _database.SaveChanges();
        }

        public void DeleteTask(long id)
        {
            _database.Tasks.Where(task => task.Id == id).ExecuteDelete();
        }

        public List<UserTask> GetAll()
        {
            return _database.Tasks.ToList();
        }

        public UserTask GetUserTaskByName(string title)
        {
            return (UserTask)_database.Tasks.Local.Where(t => t.Title == title);
        }
    }
}
