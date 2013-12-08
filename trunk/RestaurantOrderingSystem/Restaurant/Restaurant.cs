
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RestaurantOrderingSystem
{
    class Restaurant
    {
        // Properties
        public NameStruct Name { get; set; }
        public string Address { get; set; }
        public Corporate Corporate { get; set; }
        public List<Zone> Zones { get; set; }
        public List<Employee> Personnel { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}