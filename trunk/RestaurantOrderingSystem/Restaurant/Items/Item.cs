using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystem
{
    public abstract class Item
    {
        // Properties
        public string Name { get; set; }
        public string ItemDescription { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
}
