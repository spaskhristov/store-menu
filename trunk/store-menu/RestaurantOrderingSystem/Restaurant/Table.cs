using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystem
{
    class Table
    {
        // Properties
        public Zone Zone { get; set; }
        public List<Client> Clients { get; set; }
    }
}
