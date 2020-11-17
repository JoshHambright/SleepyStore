using SleepyStore.Data;
using SleepyStore.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepyStore.Services
{
    class ItemService
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
