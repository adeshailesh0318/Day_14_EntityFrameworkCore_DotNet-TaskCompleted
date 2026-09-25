using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProductApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {


        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [HttpGet]
        public IActionResult GetAllProduct(string? search = null,decimal? minPrice = null,decimal? maxPrice = null,string? sort = null)
        {
            try
            {
                var products = _productService.GetAllProducts();

                // By default all products
                if (products == null)
                {
                    return NotFound("No products found");
                }

                // Filter by product name
                if (!string.IsNullOrEmpty(search))
                {
                    products = products
                        .Where(p => p.ProductName != null &&
                                    p.ProductName.Contains(search,
                                        StringComparison.OrdinalIgnoreCase))
                        .ToList();
                }

                // Minimum price
                if (minPrice.HasValue)
                {
                    products = products
                        .Where(p => p.Price >= minPrice.Value)
                        .ToList();
                }

                // Maximum price
                if (maxPrice.HasValue)
                {
                    products = products
                        .Where(p => p.Price <= maxPrice.Value)
                        .ToList();
                }

                // Sorting
                if (sort == "priceAsc")
                {
                    products = products
                        .OrderBy(p => p.Price)
                        .ToList();
                }
                else if (sort == "priceDesc")
                {
                    products = products
                        .OrderByDescending(p => p.Price)
                        .ToList();
                }
                else if (sort == "nameAsc")
                {
                    products = products
                        .OrderBy(p => p.ProductName)
                        .ToList();
                }
                else if (sort == "nameDesc")
                {
                    products = products
                        .OrderByDescending(p => p.ProductName)
                        .ToList();
                }

                // If filter gives no result
                if (products.Count == 0)
                {
                    return NotFound("No products found");
                }

                return Ok(products); // 200
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetProdutById(int id) 
        {

            try 
            {


                if (id > 0) 
                {
                
                   ProductDTO GetProdu=
                        _productService.GetProductById(id);
                    if (GetProdu != null)
                    {
                        return Ok(GetProdu);
                    }
                    else 
                    {

                        return NotFound();
                    }
                }
                else 
                {

                    return BadRequest("id cannot be zero!");
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductDTO productDTO)
        {
            try
            {

                if (productDTO != null)
                {
    
                    _productService.CreateProduct(productDTO);
                    return Ok(true);
                }
                else 
                {
                
                    return BadRequest("product cannot be null");
                }
            }
            catch (Exception ex) 
            {

                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }


        [HttpPut]
        public IActionResult Update(int id, ProductDTO productDTO) 
        {
            try
            {


                if (id > 0)
                {

                    if (id == productDTO.ProductId && productDTO != null)
                    {

                        _productService.UpdateProduct(productDTO);
                        return Ok(true);
                    }
                    else 
                    {

                        return BadRequest("id and productid should be same & product cannot be null");
                    }
                }
                else 
                {

                    return BadRequest("id is greather then zero!");
                }
            }
            catch (Exception ex) 
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }


        [HttpDelete]
        public IActionResult Delete(int id) 
        {

            try 
            {
                if (id > 0)
                {

                    _productService.DeleteProduct(id);
                    return Ok(true);
                }
                else 
                {
                    return BadRequest("id is greather then zero!");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }

    }
}
