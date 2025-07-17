using Microsoft.AspNetCore.Mvc;
using ZondaAPI.Models;
using ZondaAPI.Services;

namespace ZondaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IDataService _dataService;

        public ProductsController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ZondaProduct>> GetProducts()
        {
            return Ok(_dataService.GetAllProducts());
        }

        [HttpGet("{id}")]
        public ActionResult<ZondaProduct> GetProduct(int id)
        {
            var product = _dataService.GetProductById(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpGet("customer/{customerId}")]
        public ActionResult<IEnumerable<ZondaProduct>> GetProductsByCustomer(int customerId)
        {
            return Ok(_dataService.GetProductsByCustomerId(customerId));
        }

        [HttpPost]
        public ActionResult<ZondaProduct> CreateProduct(ZondaProduct product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var created = _dataService.AddProduct(product);
            return CreatedAtAction(nameof(GetProduct), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, ZondaProduct product)
        {
            if (id != product.Id)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var updated = _dataService.UpdateProduct(product);
            if (updated == null)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var success = _dataService.DeleteProduct(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
} 