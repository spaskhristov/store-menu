using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystem
{
    abstract class Employee : Person
    {
        // Constructor
        public Employee(string name) : base(name) { }
    }
}
