using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task = TaskManagementWebApp.Models.Task;
using TaskManagementWebApp.Services;

namespace TaskManagementWebApp.Pages
{
    public class EditModel : PageModel
    {
        private readonly TaskManagerService _taskManagerService;

        public EditModel(TaskManagerService taskManagerService)
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
                return NotFound();  // Return 404 if task not found
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();  // Return to the page if the model is not valid
            }

            try
            {
                _taskManagerService.UpdateTask(Task);
            }
            catch (InvalidOperationException ex)
            {
                // Handle the exception, perhaps log it or display a message to the user
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }

            return RedirectToPage("/Index");  // Redirect to the Index page after a successful update
        }
    }
}