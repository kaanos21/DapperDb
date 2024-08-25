using DapperNight.Dtos.ProductDtos;
using DapperNight.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperNight.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> ProductList()
        {
            var values=await _productService.GetAllProductAsync();
            return View(values);
        }
        public async Task<IActionResult> ProductListWithCategory()
        {
            var values = await _productService.GetAllProductsAsync();
            return View(values);
        }
        public async Task<IActionResult> ProductListWithCategoryProcedure()
        {
            var values=await _productService.GetAllProductWithCategoryProcAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreatedProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatedProduct(CreateProductDto product)
        {
            await _productService.CreateProductAsync(product);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("ProductList");
        }
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var value=await _productService.GetByIdProductAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto product)
        {
            await _productService.UpdateProductAsync(product);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> ProductCount()
        {
            int value=await _productService.GetProductCountAsync();
            ViewBag.a=value;
            return View();
        }
    }
}