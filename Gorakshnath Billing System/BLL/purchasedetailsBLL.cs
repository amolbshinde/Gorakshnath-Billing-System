﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gorakshnath_Billing_System.BLL
{
    class purchasedetailsBLL
    {
        public int id { get; set; }
        public int productid { get; set; }
        public decimal rate { get; set; }
        public decimal qty { get; set; }
        public decimal total { get; set; }
        public int supid { get; set; }
        public DateTime addeddate { get; set; }
    }
}
