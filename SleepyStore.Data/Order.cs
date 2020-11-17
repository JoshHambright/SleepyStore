using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepyStore.Data
{
    public class Order
    {
        [Key]
        public int OrderNumber { get; set; }
        [Required]
        public double OrderTotal { get; set; }
        public Status OrderStatus { get; set; }
        public DateTime OrderedUtc { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime LastUpdatedUtc { get; set; }
        public Guid UserID { get; set; }
        //public virtual Product Product { get; set; }
        //public virtual List<LineItem> LineItems { get; set; } = new List<LineItem>()
    }
        public enum Status
    {
        Open,
        Shipped,
        Delivered,
        Cancelled
    }
}
