using SleepyStore.Data;
using SleepyStore.Models;
using SleepyStore.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepyStore.Services
{
    public class CategoryService
    {
        //GUID
        private readonly Guid _userId;

        public CategoryService(Guid userId)
        {
            _userId = userId;
        }

        //Create
        public bool CreateCat(CategoryCreate model)
        {
            var entity = new Category()
            {
                CategoryName = model.CategoryName,
                CreatedUtc = DateTime.Now
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //Read 
        //Get All Categories
        public IEnumerable<CategoryListItem> GetCats()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Categories
                        .Select(
                            e => 
                                new CategoryListItem
                                {
                                    CategoryID = e.CategoryID,
                                    CategoryName = e.CategoryName
                                }
                        );
                return query.ToArray();
            }
        }

        //Get Category by ID
        public CategoryDetail GetCat(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var cat =
                    ctx
                        .Categories
                        .Single(c => c.CategoryID == id);
                return
                    new CategoryDetail
                    {
                        CategoryID = cat.CategoryID,
                        CategoryName = cat.CategoryName,
                        CreatedUtc = cat.CreatedUtc,
                        //UpdatedUtc? = cat.UpdatedUtc,
                        //Items = cat.Items.Select ( 
                        // FUNCTION FOR CONVERTING VIRTUAL LIST OF ITEMS TO REAL LIST ).ToList()
                    };
            }
        }

    }
}
