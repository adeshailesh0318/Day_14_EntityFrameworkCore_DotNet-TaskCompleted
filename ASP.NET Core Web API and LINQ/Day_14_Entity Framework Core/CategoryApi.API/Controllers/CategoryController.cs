using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CategoryApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;
        private readonly IProductRepository _productServices;

        public CategoryController(ICategoryService categoryService, IProductRepository productServices)
        {
            _categoryService = categoryService;
            _productServices = productServices;
        }

       
        [HttpGet]

        public IActionResult GetAllCategories()
        {
            var categories = _categoryService.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("{categoryName}/products")]
        public ActionResult<IEnumerable<ProductDTO>> GetProductsByCategoryName(string categoryName)
        {
            // Step 1: Find the category by name (case-insensitive)
            var category = _categoryService.GetAllCategories()
                .FirstOrDefault(c => c.CategoryName.ToLower() == categoryName.ToLower());

            if (category == null)
                return NotFound($"Category '{categoryName}' not found.");

            // Step 2: Get all products of that category
            var products = _productServices.GetProducts()
                .Where(p => p.CategoryId == category.CategoryId)
                .Select(p => new ProductDTO
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    CategoryId = p.CategoryId
                })
                .ToList();

            return Ok(products);
        }
    }
}
