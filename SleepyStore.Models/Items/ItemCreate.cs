using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepyStore.Models
{
    public class ItemCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Inventory { get; set; }
    }
}
