using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public byte GenreId { get; set; }

        [Required]
        [Display(Name="Release Date")]
        public DateTimeOffset ReleaseDate { get; set; }

        [Required]
        [Display(Name="Date Added")]
        public DateTimeOffset DateAdded { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "The number in stock must be between 1 and 20.")]
        [Display(Name="Number in stock")]
        public int NumberInStock { get; set; }

        [Required]
        [Display(Name="Number Available")]
        [Range(0, 20, ErrorMessage = "The number available must be between 0 and 20")]
        public int NumberAvailable { get; set; }
    }
}