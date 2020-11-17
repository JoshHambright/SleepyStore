using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepyStore.Data
{
    public class LineItem
    {
        [Key]
        public int LineItemID { get; set; }

        [ForeignKey(nameof(Order))]

        public int OrderNumber { get; set; }
        [ForeignKey(nameof(Item))]
        public int ItemID { get; set; }
        public virtual Item Item { get; set; }
        public int Quantity { get; set; }
        public double subtotal
        {
            get
            {
                return Quantity * Item.Price;
            }
        }
    }
}
