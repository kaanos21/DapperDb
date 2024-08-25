using DapperNight.Dtos.ProductDtos;

namespace DapperNight.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();

        Task<List<ResultProductWithCategoryDto>> GetAllProductsAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryProcAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(int id);
        Task<GetByIdProductDto> GetByIdProductAsync(int id);
        Task<int> GetProductCountAsync();
    }
}
