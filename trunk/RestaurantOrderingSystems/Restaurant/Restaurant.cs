using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystems
{
    class Restaurant
    {
        // Properties
        public string Name { get; set; }
        public string Address { get; set; }
        public Corporate Corporate { get; set; }
        public List<Zone> Zones { get; set; }
    }
}
