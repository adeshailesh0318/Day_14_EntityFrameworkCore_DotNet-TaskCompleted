using Authen.DAL;
using System.Collections.Generic;

public interface ICategoryRepositories
{
    List<Category> GetAllCategories();
    Category GetCateById(int id);
    void CreateCategory(Category category);
    void UpdateCategory(Category category);
    void DeleteCategory(int id);
}