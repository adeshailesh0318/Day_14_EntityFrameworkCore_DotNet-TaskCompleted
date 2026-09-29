
using Authen.DAL;
using System.Collections.Generic;
using System.Linq;

public class CategoryRepositories : ICategoryRepositories
{

    private readonly AuthenDBContext _authenDBContext;

    public CategoryRepositories(AuthenDBContext authenDBContext)
    {
        _authenDBContext = authenDBContext;
    }


    public List<Category> GetAllCategories()
    {
        return _authenDBContext.Categories.ToList();
    }


    public Category GetCateById(int id)
    {
       return _authenDBContext.Categories.Find(id);
    }


    public void CreateCategory(Category category)
    {
        _authenDBContext.Categories.Add(category);
        _authenDBContext.SaveChanges();
    }

    public void UpdateCategory(Category category)
    {
        _authenDBContext.Categories.Attach(category);
        _authenDBContext.Entry(category).State = System.Data.EntityState.Modified;
        _authenDBContext.SaveChanges();
    }

    public void DeleteCategory(int id)
    {
       var GetCate=
            _authenDBContext.Categories.Find(id);
        _authenDBContext.Categories.Remove(GetCate);
        _authenDBContext.SaveChanges();
    }

}