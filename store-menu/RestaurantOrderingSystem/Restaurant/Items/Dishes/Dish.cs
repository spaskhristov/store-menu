using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystem
{
    class Dish : Item
    {
        // Properties
        public DishType DishType { get; set; }
        public string[] Ingredients { get; set; }
        public double TimeToCook { get; set; }
    }
}
