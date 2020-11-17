using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepyStore.Models.Items
{
    public class ItemDetail
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Inventory { get; set; }
        public DateTime CreatedUtc { get; set; }
    }
}
