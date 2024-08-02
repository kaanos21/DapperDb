using DapperNight.Dtos.CategoryDtos;

namespace DapperNight.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(int id);
        Task <GetByIdCategoryDto> GetByIdCategoryAsync(int id);
    }
}
