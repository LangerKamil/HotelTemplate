using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelApplication.Models;
using HotelApplication.DTOs;
using AutoMapper;

namespace HotelApplication.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET /api/Services/Customers
        [Route("api/Services/Customers")]
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDTO>);
        }

        // GET /api/Services/Customers/1
        [Route("api/Services/Customers/{id}")]
        public CustomerDTO GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Customer,CustomerDTO>(customer);
        }

        // POST /api/Services/Customers
        [HttpPost]
        [Route("api/Services/Customers")]
        public CustomerDTO CreateCustomer (CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customer = Mapper.Map<CustomerDTO, Customer>(customerDTO);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDTO.Id = customer.Id;

            return customerDTO;

        }

        // PUT /api/Services/Customers/1
        [HttpPut]
        [Route("api/Services/Customers/{id}")]
        public void UpdateCustomer (int id, CustomerDTO customerDTO)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c=>c.Id==id);

            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDTO, customerInDb);

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
