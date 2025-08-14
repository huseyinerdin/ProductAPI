using ProductAPI.Application.DTOs;
using ProductAPI.Domain.Entities;
using ProductAPI.Infrastructure.Repositories;

namespace ProductAPI.Application.Services
{
    public class ProductsService(IGenericRepository<Product> productRepository) : IProductsService
    {
        private readonly IGenericRepository<Product> _productRepository = productRepository;
        public async Task<ProductResponseDto?> CreateAsync(ProductCreateDto dto)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
            };
            await _productRepository.AddAsync(product);
            var result = await _productRepository.SaveChangesAsync();

            return result ? MapToResponseDto(product) : null;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return false;
            }
            _productRepository.Remove(product);
            var result = await _productRepository.SaveChangesAsync();
            return result;
        }

        public async Task<IEnumerable<ProductResponseDto>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(MapToResponseDto);
        }

        public async Task<ProductResponseDto?> GetByIdAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return product == null ? null : MapToResponseDto(product);
        }

        private static ProductResponseDto MapToResponseDto(Product product)
        {
            return new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };
        }
    }
}
