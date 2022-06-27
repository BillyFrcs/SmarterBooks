using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmarterBooks.Models;

namespace SmarterBooks.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        [BindProperty] public Models.Books Book { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public CreateModel(ApplicationDbContext dbContext) => this._dbContext = dbContext;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public void OnGetAsync()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                await _dbContext.Books.AddAsync(Book);

                await _dbContext.SaveChangesAsync();

                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
}