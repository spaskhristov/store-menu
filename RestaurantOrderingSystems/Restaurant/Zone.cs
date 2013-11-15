using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystems
{
    class Zone
    {
        // Properties
        public string Name { get; set; }
        public Restaurant Restaurant { get; set; }
        public List<Table> Tables { get; set; }
    }
}
