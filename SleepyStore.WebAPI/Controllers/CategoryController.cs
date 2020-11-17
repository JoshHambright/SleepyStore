using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SleepyStore.Models;
using SleepyStore.Services;

namespace SleepyStore.WebAPI.Controllers
{
    public class CategoryController : ApiController
    {
        //Establish DB connection
        private CategoryService CreateCategoryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var categoryService = new CategoryService(userId);
            return categoryService;
        }

        //CREATE
        //Create New Category

        public IHttpActionResult Category(CategoryCreate cat)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCategoryService();

            if (!service.CreateCat(cat))
                return InternalServerError();
            return Ok();
        }

        //READ
        //Get All Categories
        public IHttpActionResult Get()
        {
            CategoryService categoryService = CreateCategoryService();
            var categories = categoryService.GetCats();
            return Ok(categories);
        }

        //Get Category By ID
        public IHttpActionResult Get(int id)
        {
            CategoryService categoryService = CreateCategoryService();
            var category = categoryService.GetCats(id);
            return Ok(category);
        }
    }
}
