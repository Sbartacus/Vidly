using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Rental
    {
        public int Id { get; set; }

        [Required]
        public Customer Customer { get; set; }
        
        [Required]
        public Movie Movie { get; set; }
        
        [DisplayName("Date Rented")]
        public DateTimeOffset DateRented { get; set; }

        [DisplayName("Date Returned")]
        public DateTimeOffset? DateReturned { get; set; }
    }
}