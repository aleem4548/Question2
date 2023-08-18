using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Question2.Model;
using Question2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService customerService = new CustomerService();

        [HttpPost]
        public IActionResult AddCustomers(List<Customer> newCustomers)
        {
            customerService.AddCustomers(newCustomers);
            return Ok();
        }

        [HttpGet]
        public ActionResult<List<Customer>> GetCustomers()
        {
            var customers = customerService.GetCustomers();
            return customers;
        }
    }
}
