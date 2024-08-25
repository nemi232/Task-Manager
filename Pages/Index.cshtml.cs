using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskManagementWebApp.Models;  // Ensure this namespace is included
using TaskManagementWebApp.Services; // This is where your service is located
using System.Collections.Generic;
using Task = TaskManagementWebApp.Models.Task;

namespace TaskManagementWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly TaskManagerService _taskManagerService;

        public IndexModel(TaskManagerService taskManagerService)
        {
            _taskManagerService = taskManagerService;
        }

        public List<Task> Tasks { get; private set; }

        public void OnGet()
        {
            Tasks = new List<Task>(_taskManagerService.GetAllTasks()); // Assumes your service returns a list of tasks
        }
    }
}