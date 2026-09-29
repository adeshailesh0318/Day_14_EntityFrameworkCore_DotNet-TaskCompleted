


public class CategoryService : ICategoryService
{

    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public List<CategoryDTO> GetAllCategories()
    {

       return _categoryRepository.GetAllCategories().Select(c=>new CategoryDTO()
       {
       
           CategoryId = c.CategoryId,
           CategoryName = c.CategoryName

       }).ToList();

    }
}