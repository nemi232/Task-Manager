using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskManagementWebApp.Services;

namespace TaskManagementWebApp.Pages.Tasks
{
    public class CreateModel : PageModel
    {
        private readonly TaskManagerService _taskManagerService;

        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Description { get; set; }

        public CreateModel(TaskManagerService taskManagerService)
        {
            _taskManagerService = taskManagerService;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _taskManagerService.CreateTask(Name, Description);
            return RedirectToPage("Index");
        }
    }
}