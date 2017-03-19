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

        [Required]
        public Genre Genre { get; set; }
        public byte GenreId { get; set; }

        [Required]
        public DateTimeOffset ReleaseDate { get; set; }

        [Required]
        public DateTimeOffset DateAdded { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int NumberInStock { get; set; }
    }
}