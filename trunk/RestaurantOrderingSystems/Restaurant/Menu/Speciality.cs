using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystems
{
    class Speciality
    {
        // Properties
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public List<Item> Items { get; set; }
    }
}
