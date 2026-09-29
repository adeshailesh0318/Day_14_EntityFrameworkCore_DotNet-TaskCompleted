using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Authen.API.Controllers
{

  
    public class CategoryController : ApiController
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [Authorize]
        [HttpGet]
        public IHttpActionResult GetAllCategories()
        {
        
           List<CategoryModel>GetAll=
                _categoryService.GetAllCategories();
            return Ok(GetAll);
        }


        [HttpGet]
        public IHttpActionResult GetCateById(int id) 
        {
            try
            {


                if (id > 0)
                {

                   CategoryModel GetCate =
                        _categoryService.GetCateById(id);
                    if (GetCate != null)
                    {
                        return Ok(GetCate);
                    }
                    else 
                    {
                        return NotFound();
                    }
                }
                else 
                {

                    return BadRequest("Category id cannot be null");
                }

            }
            catch (Exception ex) 
            {

                return InternalServerError();
            }
        }


        [Authorize(Roles ="admin")]
        [HttpPost]
        public IHttpActionResult Create(CategoryModel categoryModel) 
        {
            try
            {

                if (categoryModel != null)
                {

                    _categoryService.CreateCategory(categoryModel);
                    return Created("DefaultApi",categoryModel);
                }
                else 
                {

                    return BadRequest("null category cannot be insert");
                }
            }
            catch (Exception ex) 
            {
            
                return InternalServerError();
            }
        }


        [Authorize(Roles = "admin")]
        [HttpPut]
        public IHttpActionResult Update(int id ,CategoryModel categoryModel) 
        {
            try
            {


                if (id > 0)
                {

                    if (id == categoryModel.Id && categoryModel != null)
                    {

                        _categoryService.UpdateCategory(categoryModel);
                        return Ok(categoryModel);

                    }
                    else 
                    {

                        return BadRequest("id and categoryId Should Be Same!");
                    }
                }
                else 
                {

                    return BadRequest("id is greater then zero");
                }
            }
            catch (Exception ex) 
            {
            
                return InternalServerError();
            }
        }


        [Authorize(Roles ="admin")]
        [HttpDelete]
        public IHttpActionResult Delete(int id) 
        {
            try
            {

                if (id > 0)
                {

                   _categoryService.DeleteCategory(id);
                    return Ok(true);
                }
                else 
                {

                    return NotFound();
                }
            }
            catch (Exception ex) 
            {
            
                return InternalServerError(ex);
            }
        }



    }
}
