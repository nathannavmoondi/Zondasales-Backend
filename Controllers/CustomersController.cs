using Microsoft.AspNetCore.Mvc;
using ZondaAPI.Models;
using ZondaAPI.Services;

namespace ZondaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IDataService _dataService;

        public CustomersController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ZondaCustomer>> GetCustomers()
        {
            return Ok(_dataService.GetAllCustomers());
        }

        [HttpGet("{id}")]
        public ActionResult<ZondaCustomer> GetCustomer(int id)
        {
            var customer = _dataService.GetCustomerById(id);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }

        [HttpPost]
        public ActionResult<ZondaCustomer> CreateCustomer(ZondaCustomer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var created = _dataService.AddCustomer(customer);
            return CreatedAtAction(nameof(GetCustomer), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, ZondaCustomer customer)
        {
            if (id != customer.Id)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var updated = _dataService.UpdateCustomer(customer);
            if (updated == null)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var success = _dataService.DeleteCustomer(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
} 