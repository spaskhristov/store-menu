using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystems
{
    class Order
    {
        // Properties
        public string ID { get; set; }
        public Table Table { get; set; }
        public decimal VAT { get; set; }
        public decimal TotalPrice { get; set; }
        public int CookTime { get; set; }
        public Item[] Items { get; set; }
        public bool Paid { get; set; }
        public DateTime TimeToLive { get; set; }
        public DateTime Date { get; set; }
        public OrderState OrderState { get; set; }

        // Methods
        bool IsCooked()
        {
            return false;
        }

        bool IsPaid()
        {
            return false;
        }
    }
}
