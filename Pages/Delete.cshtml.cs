using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskManagementWebApp.Models;
using TaskManagementWebApp.Services;
using Task = TaskManagementWebApp.Models.Task;

namespace TaskManagementWebApp.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly TaskManagerService _taskManagerService;

        public DeleteModel(TaskManagerService taskManagerService)
        {
            _taskManagerService = taskManagerService;
        }

        [BindProperty]
        public Task Task { get; set; }

        public IActionResult OnGet(int id)
        {
            Task = _taskManagerService.GetTaskById(id);

            if (Task == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            _taskManagerService.DeleteTask(Task.Id);
            return RedirectToPage("/Index");
        }
    }
}