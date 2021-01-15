using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Customer.DataAccess;
using Customer.Models;
using Microsoft.AspNetCore.Authorization;

namespace Customer.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CustomersController(DatabaseContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDetail>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDetail>> GetCustomerDetail(Guid id)
        {
            var customerDetail = await _context.Customers.FindAsync(id);

            if (customerDetail == null)
            {
                return NotFound();
            }

            return customerDetail;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerDetail(Guid id, CustomerDetail customerDetail)
        {
            if (id != customerDetail.customerId)
            {
                return BadRequest();
            }

            _context.Entry(customerDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<CustomerDetail>> PostCustomerDetail(CustomerDetail customerDetail)
        {
            _context.Customers.Add(customerDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerDetail", new { id = customerDetail.customerId }, customerDetail) ;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerDetail(Guid id)
        {
            var customerDetail = await _context.Customers.FindAsync(id);
            if (customerDetail == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customerDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerDetailExists(Guid id)
        {
            return _context.Customers.Any(e => e.customerId == id);
        }

        //Exception Testing

        [HttpGet]
        public string GetException(int id,string name)
        {
            string word = "test";
            if (word.Length > 0)
            {
                //throw new AppException("My Custom Exception");
            }
            int t = 5;
            var t1 = t /( t - t);
            return word;
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            string[] arrRetValues = null;
            if (arrRetValues.Length > 0)
            { }
            return arrRetValues;
        }
    }
}
