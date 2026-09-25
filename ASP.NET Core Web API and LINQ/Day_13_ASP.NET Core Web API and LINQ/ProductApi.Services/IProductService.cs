
using ProductApi.DAL.Models;

public interface IProductService
{
    List<ProductDTO> GetAllProducts();
    ProductDTO GetProductById(int id);
    void CreateProduct(ProductDTO product);
    void UpdateProduct(ProductDTO product);
    void DeleteProduct(int id);
}