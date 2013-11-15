using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystems
{
    class Menu
    {
        // Properties
        public string Name { get; set; }
        public Speciality Speciality { get; set; }
        public List<Item> Items { get; set; }
        public DateTime Date { get; set; }
    }
}
