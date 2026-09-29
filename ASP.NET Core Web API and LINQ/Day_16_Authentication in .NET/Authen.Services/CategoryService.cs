

using Authen.DAL;
using System.Collections.Generic;
using System.Linq;

public class CategoryService : ICategoryService
{

    private readonly ICategoryRepositories _categoryRepositories;

    public CategoryService(ICategoryRepositories categoryRepositories)
    {
        _categoryRepositories = categoryRepositories;
    }



    public List<CategoryModel> GetAllCategories()
    {

        return _categoryRepositories.GetAllCategories().Select(u => new CategoryModel()
        {

            Id = u.Id,
            Name = u.Name,
            Description = u.Description

        }).ToList();
    }

    public CategoryModel GetCateById(int id)
    {
       Category dbCategory =
            _categoryRepositories.GetCateById(id);

        if (dbCategory != null) 
        {
            CategoryModel uiModels = new CategoryModel()
            {


                Id = dbCategory.Id,
                Name = dbCategory.Name,
                Description = dbCategory.Description,
            };

            return uiModels;
        }

        return null;
    }


    public void CreateCategory(CategoryModel category)
    {
        Category dbCategory = new Category()
        {

            Id = category.Id,
            Name = category.Name,
            Description = category.Description,
        };
        _categoryRepositories.CreateCategory(dbCategory);

    }


    public void UpdateCategory(CategoryModel category)
    {
        Category dbCategory = new Category()
        {

            Id = category.Id,
            Name = category.Name,
            Description = category.Description,

        };
        _categoryRepositories.UpdateCategory(dbCategory);

    }


    public void DeleteCategory(int id)
    {
        _categoryRepositories.DeleteCategory(id);
    }

}