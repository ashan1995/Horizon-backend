using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorizonWebApi.Models
{
    public class BillPost
    {
        public String customerName { get; set; }
        public float total { get; set; }
        public int[] itemIds { get; set; }
    }
}
