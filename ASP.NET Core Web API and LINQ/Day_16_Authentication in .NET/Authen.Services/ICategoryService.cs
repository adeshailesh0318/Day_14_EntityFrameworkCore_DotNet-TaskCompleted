
using Authen.DAL;
using System.Collections.Generic;

public interface ICategoryService
{
    List<CategoryModel> GetAllCategories();
    CategoryModel GetCateById(int id);
    void CreateCategory(CategoryModel category);
    void UpdateCategory(CategoryModel category);
    void DeleteCategory(int id);
}
