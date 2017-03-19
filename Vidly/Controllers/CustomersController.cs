using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        
        // GET: Customers
        public ActionResult All()
        {
            var customers = _context
                .Customers
                .Include(c => c.MembershipType)
                .ToList();
            var allCustomersViewModel = new AllCustomersViewModel { Customers = customers };
            return View(allCustomersViewModel);
        }

        public ActionResult Detail(int id)
        {
            var customer = _context
                .Customers
                .Include(c => c.MembershipType)
                .SingleOrDefault(x => x.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        private readonly ApplicationDbContext _context;
    }
}