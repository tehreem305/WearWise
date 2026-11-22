
using Microsoft.AspNetCore.Mvc;
using WearWise.Interfaces;
using WearWise.Models;

namespace WearWise.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _repository;

        public CategoriesController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Add(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.Name))
                return BadRequest("Category name is required.");

            await _repository.AddAsync(category);
            return Ok(category);
        }
    }
}
