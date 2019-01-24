﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorizonWebApi.Models
{
    public class Bill
    {
        public int billId { get; set; }
        public String customerName { get; set; }
        public float total { get; set; }

        public List<BillItem> BillItems { get; set; }
    }
}
