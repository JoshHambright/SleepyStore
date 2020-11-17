using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepyStore.Data
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        //Uncomment below to link Item and Category Class
        //public virtual List<Item> Items { get; set; } = new List<Item>();
    }
}
