using System.Collections.Generic;
using System.Linq;
using TaskManagementWebApp.Models;
using Task = TaskManagementWebApp.Models.Task; // Ensure the correct namespace is being used


namespace TaskManagementWebApp.Services
{
    public class TaskManagerService
    {
        private readonly List<Models.Task> _tasks = new List<Models.Task>();

        public IEnumerable<Models.Task> GetAllTasks()
        {
            return _tasks;
        }

        public Task GetTaskById(int id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }


        public void CreateTask(string name, string description)
        {
            var newTask = new Models.Task { Id = _tasks.Count + 1, Name = name, Description = description };
            _tasks.Add(newTask);
        }

        public void EditTask(int taskId, string name, string description)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == taskId);
            if (task != null)
            {
                task.Name = name;
                task.Description = description;
            }
        }

        public void DeleteTask(int taskId)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == taskId);
            if (task != null)
            {
                _tasks.Remove(task);
            }
        }
        public void UpdateTask(Task updatedTask)
        {
            var existingTask = GetTaskById(updatedTask.Id);
    
            if (existingTask == null)
            {
                // Handle the case where the task is not found.
                throw new InvalidOperationException("Task not found.");
            }

            existingTask.Name = updatedTask.Name;
            existingTask.Description = updatedTask.Description;
        }

        
    }
}