using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmarterBooks.Models;

namespace SmarterBooks.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        [BindProperty] public Models.Books Book { get; set; }

        public EditModel(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task OnGetAsync(int id)
        {
            Book = await _dbContext.Books.FindAsync(id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var bookDb = await _dbContext.Books.FindAsync(Book.Id);

                bookDb.Name = Book.Name;
                bookDb.Author = Book.Author;
                bookDb.ISBN = Book.ISBN;

                await _dbContext.SaveChangesAsync();

                return RedirectToPage("/Index");
            }

            return RedirectToPage();
        }
    }
}