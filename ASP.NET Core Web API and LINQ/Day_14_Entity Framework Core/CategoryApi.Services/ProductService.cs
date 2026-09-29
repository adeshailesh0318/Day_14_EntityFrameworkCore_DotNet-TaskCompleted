


public class ProductService : IProductService
{

    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public List<ProductDTO> GetProducts()
    {
       
        var products = _productRepository.GetProducts();


        return products.Select(p => new ProductDTO
        {
            ProductId = p.ProductId,
            ProductName = p.ProductName,
            Price = p.Price,
            Quantity = p.Quantity,
            CategoryId = p.CategoryId,
           
        }).ToList();
    }
}