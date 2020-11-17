
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
    public class ItemSevice
    {
        private readonly Guid _userId;

        public ItemSevice (Guid userId)
        {
            _userId = userId;
        }
        public bool CreateItem(ItemCreate model)
        {
            var entity = new Item()
            {
                Name= model.Name,
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
        public IEnumerable<ItemDetails> GetItemDetails()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Items
                    .Select(e => new ItemDetails
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
    }
}
