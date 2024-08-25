using DapperNight.Dtos.PropertyDtos;

namespace DapperNight.Services.PropertyServices
{
    public interface IPropertyService
    {
        public Task<List<ResultPropertyDto>> GetPropertiesWithFilterAsync(FilterPropertyDto filterPropertyDto);
        public Task<ResultPropertyWithImagesDto> GetPropertiesByIdAsync(FilterPropertyByIdDto resultPropertyByIdDto);
    }
}
