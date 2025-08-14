using Microsoft.AspNetCore.Mvc;
using ProductAPI.Application.DTOs;
using ProductAPI.Application.Services;

namespace ProductAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductsService productsService) : ControllerBase
    {
        private readonly IProductsService _productsService = productsService;

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductCreateDto dto)
        {
            var created = await _productsService.CreateAsync(dto);
            return created is null ? BadRequest("Product could not be created.")
                : CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productsService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await _productsService.GetByIdAsync(id);
            return product is null ? NotFound() : Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var deleted = await _productsService.DeleteAsync(id);
            return deleted ? NoContent() : BadRequest("Product could bot be deleted.");
        }
    }
}
