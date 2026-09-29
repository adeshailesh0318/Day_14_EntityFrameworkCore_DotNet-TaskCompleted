


public class CategoryRepository : ICategoryRepository
{


    private readonly ProductDBContext _context;

    public CategoryRepository(ProductDBContext context)
    {
        _context = context;
    }

    public List<Category> GetAllCategories()
    {
        return _context.Categories.ToList();
    }


}