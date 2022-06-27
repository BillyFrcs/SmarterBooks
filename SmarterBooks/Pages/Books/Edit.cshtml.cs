using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmarterBooks.Models;

namespace SmarterBooks.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        [BindProperty] public Models.Books Book { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public EditModel(ApplicationDbContext dbContext) => this._dbContext = dbContext;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public async Task OnGetAsync(int? id)
        {
            Book = await _dbContext.Books.FindAsync(id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var book = await _dbContext.Books.FindAsync(Book.Id);

                if (book != null)
                {
                    book.Name = Book.Name;
                    book.Author = Book.Author;
                    book.ISBN = Book.ISBN;

                    await _dbContext.SaveChangesAsync();

                    return RedirectToPage("/Index");
                }
            }

            return RedirectToPage();
        }
    }
}