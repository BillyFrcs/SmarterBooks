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

namespace SmarterBooks.Pages.Books
{
     public class Index : PageModel
     {
          private readonly ApplicationDbContext _dbContext;

          public IEnumerable<Book> Books { get; set; }

          public Index(ApplicationDbContext dbContext)
          {
               _dbContext = dbContext;
          }

          public async Task OnGet()
          {
               Books = await _dbContext.Books.ToListAsync();
          }
     }
}