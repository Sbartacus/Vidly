using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto newRentalDto)
        {
            var customer = _context.Customers.Single(x => x.Id == newRentalDto.CustomerId);
            if (customer == null)
            {
                return BadRequest();
            }

            var movies = _context.Movies.Where(x => newRentalDto.MovieIds.Contains(x.Id)).ToList();
            
            var dteNow = DateTimeOffset.Now;

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                {
                    return BadRequest("Movie is not available.");
                }

                movie.NumberAvailable--;
                var newRental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = dteNow

                };
                _context.Rentals.Add(newRental);
            }
            _context.SaveChanges();

            return Ok();
        }

        private readonly ApplicationDbContext _context;
    }
}