using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //GET: Movies/All
        public ActionResult All()
        {
            var movies = _context
                .Movies
                .Include(c => c.Genre)
                .ToList();
            var allMoviesViewModel = new AllMoviesViewModel() { Movies = movies };
            return View(allMoviesViewModel);
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie()
            {
                Name = "Shrek"
            };

            var customers = new List<Customer>
            {
                new Customer {Name = "Customer1"},
                new Customer {Name = "Customer2"}

            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + " / " + month);
        }

        public ActionResult Detail(int id)
        {
            var movie = _context
                .Movies
                .Include(c => c.Genre)
                .SingleOrDefault(x => x.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        private readonly ApplicationDbContext _context;
    }
}