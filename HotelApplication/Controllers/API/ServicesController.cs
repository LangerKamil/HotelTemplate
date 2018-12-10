using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelApplication.Models;

namespace HotelApplication.Controllers.API
{
    public class ServicesController : ApiController
    {
        private ApplicationDbContext _context;

        public ServicesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/Services/Customers
        [Route("api/Services/Customers")]
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        // GET /api/Services/Customers/1
        [Route("api/Services/Customers/{id}")]
        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return customer;
        }

        // POST /api/Services/Customers
        [HttpPost]
        [Route("api/Services/Customers")]
        public Customer CreateCustomer (Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;

        }

        // PUT /api/Services/Customers/1
        [HttpPut]
        [Route("api/Services/Customers/{id}")]
        public void UpdateCustomer (int id, Customer customer)
        {
            var DBcustomer = _context.Customers.SingleOrDefault(c=>c.Id==id);

            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            if (DBcustomer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            DBcustomer.FirstName = customer.FirstName;
            DBcustomer.LastName = customer.LastName;
            DBcustomer.DateOfBirth = customer.DateOfBirth;
            DBcustomer.Gender= customer.Gender;
            DBcustomer.EmailAddress= customer.EmailAddress;
            DBcustomer.IDNumber= customer.IDNumber;
            DBcustomer.PhoneNumber= customer.PhoneNumber;

            _context.SaveChanges();
        }

        // DELETE /api/Services/Customers/1
        [HttpDelete]
        [Route("api/Services/Customers/{id}")]
        public void DeleteCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}
