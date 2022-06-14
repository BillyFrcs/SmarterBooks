using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmarterBooks.Models;

namespace SmarterBooks.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public BookController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _dbContext.Books.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var bookDb = await _dbContext.Books.FirstOrDefaultAsync(item => item.Id == id);

            if (bookDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _dbContext.Books.Remove(bookDb);

            await _dbContext.SaveChangesAsync();

            return Json(new { success = true, message = "Successfully deleted" });
        }
    }
}