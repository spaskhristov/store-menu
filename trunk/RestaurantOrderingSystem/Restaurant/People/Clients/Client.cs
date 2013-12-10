using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystem
{
    abstract class Client : Person
    {
        // Constructor
        public Client(string name) : base(name) { }

        // Method
        public void NewOrder()
        {

        }
    }
}
