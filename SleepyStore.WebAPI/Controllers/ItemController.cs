using Microsoft.AspNet.Identity;
using SleepyStore.Models;
using SleepyStore.Models.Categories;
using SleepyStore.Models.Items;
using SleepyStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SleepyStore.WebAPI.Controllers
{
    public class ItemController : ApiController
    {

        //Establish DB connection
        private ItemService CreateItemService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var itemService = new ItemService(userId);
            return itemService;
        }

        //CREATE
        //Create New Item

        public IHttpActionResult Item(ItemCreate item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateItemService();

            if (!service.CreateItem(item))
                return InternalServerError();
            return Ok();
        }

        //UPDATE
        //Update Item By ID
        public IHttpActionResult Put(ItemEdit item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateItemService();

            if (!service.UpdateItem(item))
                return InternalServerError();

            return Ok();
        }

        //Get Item By ID
        public IHttpActionResult Get(int id)
        {
            ItemService categoryService = CreateItemService();
            var category = categoryService.GetItemByID(id);
            return Ok(category);
        }

    }
}
