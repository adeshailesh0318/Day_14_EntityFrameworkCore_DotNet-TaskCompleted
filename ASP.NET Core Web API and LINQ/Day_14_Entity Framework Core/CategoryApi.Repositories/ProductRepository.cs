

public class ProductRepository : IProductRepository
{

    private readonly ProductDBContext _productDBContext;

    public ProductRepository(ProductDBContext productDBContext)
    {
        _productDBContext = productDBContext;
    }

    public List<Product> GetProducts()
    {
        return _productDBContext.Products.ToList();
    }
}