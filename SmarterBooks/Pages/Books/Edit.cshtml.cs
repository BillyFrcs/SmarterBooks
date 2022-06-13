using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmarterBooks.Models;

namespace SmarterBooks.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        [BindProperty] public Book Books { get; set; }

        public EditModel(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task OnGet(int id)
        {
            Books = await _dbContext.Books.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var bookDb = await _dbContext.Books.FindAsync(Books.Id);

                bookDb.Name = Books.Name;
                bookDb.Author = Books.Author;
                bookDb.ISBN = Books.ISBN;

                await _dbContext.SaveChangesAsync();

                return RedirectToPage("/Index");
            }

            return RedirectToPage();
        }
    }
}