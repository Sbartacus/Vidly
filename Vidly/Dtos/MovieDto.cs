using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        [Required]
        public byte GenreId { get; set; }

        public GenreDto Genre { get; set; }

        [Required]
        public DateTimeOffset ReleaseDate { get; set; }

        [Required]
        public DateTimeOffset DateAdded { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "The number in stock must be between 1 and 20.")]
        public int NumberInStock { get; set; }

        public byte NumberAvailable { get; set; }
    }
}