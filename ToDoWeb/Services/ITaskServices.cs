﻿using ToDoWeb.Models;

namespace ToDoWeb.Services
{
    public interface ITaskServices
    {
        List<UserTask> GetAllUserTasks();
        void CreateTask(string title, string desc, DateTime date);
        void EditTask(UserTask task);
        void DeleteTask(long id);
        UserTask GetUserTask(long id);
    }
}
