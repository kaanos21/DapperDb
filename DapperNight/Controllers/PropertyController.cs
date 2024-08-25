using DapperNight.Dtos.PropertyDtos;
using DapperNight.Services.PropertyServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Threading.Tasks;

namespace DapperNight.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet]
        public async Task<IActionResult> PropertyList()
        {
            // İlk açıldığında tüm verileri getir
            var properties = await _propertyService.GetPropertiesWithFilterAsync(null);
            return View(properties);
        }

        [HttpPost]
        public async Task<IActionResult> PropertyList(FilterPropertyDto filterPropertyDto)
        {
            // Filtreleme işlemini yap ve filtrelenmiş verileri getir
            var properties = await _propertyService.GetPropertiesWithFilterAsync(filterPropertyDto);
            return View(properties);
        }
        [HttpGet]
        public async Task<IActionResult> PropertyById(FilterPropertyByIdDto filterPropertyByIdDto)
        {
            var value=await _propertyService.GetPropertiesByIdAsync(filterPropertyByIdDto);
            return View(value);
        }
    }
}
