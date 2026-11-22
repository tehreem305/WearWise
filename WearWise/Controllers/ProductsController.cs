
using Microsoft.AspNetCore.Mvc;
using WearWise.Interfaces;
using WearWise.Models;

namespace WearWise.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            await _repository.AddAsync(product);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Product product)
        {
            if (id != product.Id)
                return BadRequest("Product ID mismatch.");

            var existing = await _repository.GetByIdAsync(id);

            if (existing == null)
                return NotFound();

            await _repository.UpdateAsync(product);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _repository.GetByIdAsync(id);

            if (existing == null)
                return NotFound();

            await _repository.DeleteAsync(id);
            return Ok(new { message = "Product deleted successfully." });
        }
    }
}
