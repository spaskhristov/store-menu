using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystem.UI
{
    public class CustomException: Exception
    {
        public string CustomMessage { get; set; }
    }
}
