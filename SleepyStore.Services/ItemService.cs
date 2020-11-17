using SleepyStore.Data;
using SleepyStore.Models.Categories;
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

                return ctx.SaveChanges() == 1;
            }
        }


        public IEnumerable<ItemDetail> GetItemDetails()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Items
                    .Select(e => new ItemDetail
                    {
                        ItemId = e.ItemId,
                        Name = e.Name,
                        Description = e.Description,
                        Price = e.Price,
                        Inventory = e.Inventory,
                        CreatedUtc = e.CreatedUtc
                    });
                return query.ToArray();
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
                        Name = model.Name,
                        Description = model.Description,
                        Price = model.Price,
                        Inventory = model.Inventory,
                        CreatedUtc = DateTime.Now
                    };
            }
        }
    }
}
