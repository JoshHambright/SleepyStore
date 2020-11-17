using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepyStore.Data
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Inventory { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime? UpdatedUtc { get; set; }

        //Remove Comments Below to link Item and Category Tables
        //public double Rating { get; set; }
        [ForeignKey(nameof(Category))]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
