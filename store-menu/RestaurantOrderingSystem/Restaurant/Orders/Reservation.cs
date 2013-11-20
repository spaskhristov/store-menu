using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystem
{
    class Reservation
    {
        // Properties
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime Date { get; set; }
        public byte NumberOfPeople { get; set; }
        public string Request { get; set; }
    }
}