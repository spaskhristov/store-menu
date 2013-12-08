using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystem
{
    struct FirmName
    {
        private string firmName;
        public void DisplyName(string name)
        {
            firmName = name;

        }
    }

    class Corporate
    {
        // Properties
        public string Name { get; set; }
        public List<Restaurant> Restaurants { get; set; }

        
    }
}
