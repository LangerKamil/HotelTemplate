using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelApplication.Models;
using HotelApplication.ViewModels;
using AutoMapper;

namespace HotelApplication.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return RedirectToAction("Customers", "Service");
        }

        //[HttpPost]
        public ActionResult NewForm()
        {
            var customer = new Customer();
            var room = _context.Rooms.ToList();
            var gender = _context.Genders.ToList();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                Rooms = room,
                Genders = gender
            };

            return View(viewModel);
        }

       
        //[HttpPut]
        public ActionResult CustomerDetails(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var room = _context.Rooms.ToList();
            var gender = _context.Genders.ToList();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                Rooms = _context.Rooms.ToList(),
                Genders = _context.Genders.ToList()
            };

            return View(viewModel);
        }


        [HttpPost]
        public ActionResult Edit(Customer customer)
        {

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);

            Mapper.Map(customer, customerInDb);

            _context.SaveChanges();

            return RedirectToAction("Customers","Service");
        }
        
    }
}