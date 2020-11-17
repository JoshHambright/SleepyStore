using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepyStore.Models.Categories
{
    public class CategoryDetail
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }
        //Uncomment below to link Item and Category Class
        //public virtual List<Item> Items { get; set; } = new List<Item>();
    }
}
