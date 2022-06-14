﻿using System.ComponentModel.DataAnnotations;

namespace SmarterBooks.Models
{
    public class Book
    {
        [Key] public int Id { get; set; }

        [Required] public string Name { get; set; }
        [Required] public string Author { get; set; }

        // International standard book number
        [Required] public string ISBN { get; set; }
    }
}