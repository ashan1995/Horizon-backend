using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorizonWebApi.Models
{
    public class BillItem
    {
        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int BillId { get; set; }
        public Bill Bill { get; set; }
    }
}
