using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;
using ToDoWeb.Models;

namespace ToDoWeb.Services.Implementation
{
    public class TaskServices : ITaskServices
    {
        //   private readonly List<UserTask> _tasks;
        private readonly Dictionary<long, UserTask> _tasks;

        public void CreateTask(string title, string desc, DateTime date)
        {
            UserTask task = new UserTask()
            {
                Header = title,
                Date = date,
                Desc = desc,
                Id = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds
            };
            Console.WriteLine(task.Id);
            //_tasks.Add(task);
            Save(task);
        }
        public UserTask GetUserTask(long id)
        {
            var serializedTasks = File.ReadAllText($"../ToDoWeb/Pages/Tasks/JsonTask/{id}.json");
            return JsonSerializer.Deserialize<UserTask>(serializedTasks);
        }
        public void EditTask(UserTask task)
        {
            Save(task);
            _tasks.Remove(task.Id);
            _tasks.Add(task.Id,task);
        }
        public void DeleteTask(long id)
        {
            _tasks.Remove(id);
        }
        public TaskServices()
        {
            /*  try
            //  {
            //      var serializedTasks = File.ReadAllText("tasks.json");
            //      _tasks = JsonSerializer.Deserialize<List<UserTask>>(serializedTasks);
            //  }
            //  catch (FileNotFoundException e)
            //  {
            //      _tasks = new List<UserTask>();
            //  }
           _tasks = new List<UserTask>(); */
            _tasks = new Dictionary<long, UserTask>();
            // GetAllUserTasks();
        }
        public List<UserTask> GetAllUserTasks()
        {
            DirectoryInfo directory = new DirectoryInfo("../ToDoWeb/Pages/Tasks/JsonTask");
            foreach (var item in directory.GetFiles())
            {
                if (Path.GetExtension(item.FullName) == ".json")
                {
                    var serializedTasks = File.ReadAllText(item.FullName);
                    UserTask tmp = JsonSerializer.Deserialize<UserTask>(serializedTasks);
                    if (!_tasks.ContainsKey(tmp.Id))
                    {
                        _tasks.Add(tmp.Id, tmp);
                        //_tasks.Add(JsonSerializer.Deserialize<UserTask>(serializedTasks));
                    }
                    //_tasks.Add(JsonSerializer.Deserialize<UserTask>(serializedTasks));
                }
            }
            return _tasks.Values.ToList<UserTask>();
        }

        private void Save(UserTask task)
        {
            var serializedTasks = JsonSerializer.Serialize(task, new JsonSerializerOptions { WriteIndented = true }); ;
            File.WriteAllText($"../ToDoWeb/Pages/Tasks/JsonTask/{task.Id}.json", serializedTasks);
        }
    }
}
