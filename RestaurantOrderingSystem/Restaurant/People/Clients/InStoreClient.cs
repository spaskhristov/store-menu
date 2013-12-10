using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystem
{
    class InStoreClient : Client
    {
        // Constructor
        public InStoreClient(string name) : base(name) { }

        // Property
        public Table Table { get; set; }
    }
}
