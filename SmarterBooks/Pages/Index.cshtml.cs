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

namespace SmarterBooks.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public IEnumerable<Book> Books { get; set; }

        [BindProperty(SupportsGet = true)] public string SearchData { get; set; }

        public IndexModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task OnGetAsync()
        {
            Books = await _dbContext.Books.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = await _dbContext.Books.FindAsync(id);

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