using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmarterBooks.Models;

namespace SmarterBooks.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        [BindProperty] public Models.Books Book { get; set; }

        public CreateModel(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

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