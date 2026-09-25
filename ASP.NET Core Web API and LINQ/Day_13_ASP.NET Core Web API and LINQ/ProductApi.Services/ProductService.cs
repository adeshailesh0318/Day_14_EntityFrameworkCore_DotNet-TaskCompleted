

using ProductApi.DAL.Models;

public class ProductService : IProductService
{


    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public List<ProductDTO> GetAllProducts()
    {
        return _repository.GetAllProducts().Select(p=>new ProductDTO() 
        {

            ProductId = p.ProductId,
            ProductName = p.ProductName,
            Price = p.Price,
            Stock = p.Stock,
            Description = p.Description,
            CategoryId= p.CategoryId,

        }).ToList();
    }

    public ProductDTO GetProductById(int id)
    {
       var GetById=
            _repository.GetProductById(id);
        if (GetById != null) 
        {
        
            ProductDTO productDTO = new ProductDTO() 
            {
            
                ProductId = GetById.ProductId,
                ProductName = GetById.ProductName,
                Price = GetById.Price,
                Stock = GetById.Stock,
                Description = GetById.Description,  
                CategoryId= GetById.CategoryId,
            };
            return productDTO;
        }
        return null;
    }

    public void CreateProduct(ProductDTO product)
    {
        Product dbProduct = new Product() 
        {
            ProductId = product.ProductId,
            ProductName = product.ProductName,
            Price = product.Price,
            Stock = product.Stock,
            Description = product.Description,
            CategoryId = product.CategoryId,
        };

        _repository.CreateProduct(dbProduct);
    }

    public void UpdateProduct(ProductDTO product)
    {
        Product dbProduct = new Product() 
        {
        
            ProductId = product.ProductId,
            ProductName = product.ProductName,
            Price = product.Price,
            Stock = product.Stock,
            Description = product.Description,
            CategoryId = product.CategoryId,

        };
        _repository.UpdateProduct(dbProduct);
    }

    public void DeleteProduct(int id)
    {
       _repository.DeleteProduct(id);
    }

}
