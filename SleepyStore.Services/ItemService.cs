using SleepyStore.Data;
using SleepyStore.Models;
using SleepyStore.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepyStore.Services
{
    public class ItemService
    {
        //GUID
        private readonly Guid _userId;

        public ItemService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateItem(ItemCreate model)
        {
            var entity = new Item()
            {
                Name = model.Name,
                CategoryID = model.CategoryID,
                Description = model.Description,
                Price = model.Price,
                Inventory = model.Inventory,
                CreatedUtc = DateTime.Now
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Items.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public bool UpdateItem(ItemEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Items
                        .Single(e => e.ItemId == model.ItemId);

                entity.ItemId = model.ItemId;
                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.Price = model.Price;
                entity.Inventory = model.Inventory;
                entity.UpdatedUtc = DateTime.Now;
                entity.CategoryID = model.CategoryID;

                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ItemListItems> GetItems()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Items
                    .Where(e => e.Inventory >= 1)
                    .Select(
                    e => new ItemListItems
                    {
                        ItemId = e.ItemId,
                        Name = e.Name,
                        Inventory = e.Inventory,
                        CategoryID = e.CategoryID
                    });
                return query.ToArray();
            }
        }



        public ItemDetail GetItemByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var model =
                    ctx
                        .Items
                        .Single(i => i.ItemId == id);
                return
                    new ItemDetail
                    {
                        ItemId = model.ItemId,
                        Name = model.Name,
                        Description = model.Description,
                        Price = model.Price,
                        Inventory = model.Inventory,
                        CategoryID = model.CategoryID,
                        CategoryName = model.Category.CategoryName,
                        CreatedUtc = DateTime.Now
                    };
            }
        }
      
        public bool DeleteItem(int itemId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Items
                    .Single(e => e.ItemId == itemId);
                ctx.Items.Remove(entity);

                return ctx.SaveChanges() == 1;
            }


        }

    }
}
