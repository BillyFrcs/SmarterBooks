using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using SmarterBooks.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SmarterBooks.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public IEnumerable<Models.Books> Book { get; set; }
        public IList<Models.Books> ListBook;

        [BindProperty(SupportsGet = true)] public string SearchData { get; set; }

        public IndexModel(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task OnGetAsync()
        {
            IQueryable<Models.Books> book = from Books in _dbContext.Books select Books;
                          
            if (!string.IsNullOrEmpty(SearchData))
            {
                book = book.Where(data =>
                    data.Name.Contains(SearchData) || data.Author.Contains(SearchData) ||
                    data.ISBN.Contains(SearchData));
            }

            ListBook = await book.ToListAsync();

            // Use this if we didn't use IList
            // Books = await _dbContext.Books.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            Models.Books book = await _dbContext.Books.FindAsync(id);

            if (book != null)
            {
                _dbContext.Books.Remove(book);

                await _dbContext.SaveChangesAsync();

                return RedirectToPage("/Index");
            }

            return NotFound();
        }
    }
}