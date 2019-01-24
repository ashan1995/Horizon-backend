using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorizonWebApi.Models
{
    public class Item
    {
        public int itemId { get; set; }
        public String name { get; set; }
        public float unitPrice { get; set; }
        public String category { get; set; }
        public int stock { get; set; }

        public List<BillItem> BillItems { get; set; }
    }
}
