﻿using System.ComponentModel.DataAnnotations;

namespace libraryManagementSystem.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Author { get; set; }
    }
}
