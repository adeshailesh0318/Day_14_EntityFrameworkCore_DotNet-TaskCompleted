

using ProductApi.DAL.Models;

public class ProductRepository : IProductRepository
{

    private readonly ProductDBContext _productDBContext;

    public ProductRepository(ProductDBContext productDBContext)
    {
        this._productDBContext = productDBContext;
    }



    public List<Product> GetAllProducts()
    {
       return _productDBContext.Products.ToList();
    }
    public Product GetProductById(int id)
    {
       return _productDBContext.Products.Find(id);
    }
    public void CreateProduct(Product product)
    {
        _productDBContext.Add(product);
        _productDBContext.SaveChanges();
    }
    public void UpdateProduct(Product product)
    {
        _productDBContext.Products.Attach(product);
        _productDBContext.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        _productDBContext.SaveChanges();
    }
    public void DeleteProduct(int id)
    {
       var GetCateById=
            _productDBContext.Products.Find(id);
        _productDBContext.Products.Remove(GetCateById);
        _productDBContext.SaveChanges();
    }

}