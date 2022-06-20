using System.ComponentModel.DataAnnotations;

namespace SmarterBooks.Models
{
    public class Books
    {
        [Key] public int Id { get; set; }

        [Required] public string? Name { get; set; }
        [Required] public string? Author { get; set; }

        // International standard book number
        [Required] public string? ISBN { get; set; }

        // Date time      
        [DataType(DataType.Date)] public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}