using ProductAPI.Application.DTOs;

namespace ProductAPI.Application.Services
{
    public interface IProductsService
    {
        Task<ProductResponseDto?> CreateAsync(ProductCreateDto dto);

        Task<IEnumerable<ProductResponseDto>> GetAllAsync();

        Task<ProductResponseDto?> GetByIdAsync(Guid id);

        Task<bool> DeleteAsync(Guid id);
    }
}
