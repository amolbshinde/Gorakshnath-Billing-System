﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gorakshnath_Billing_System.BLL
{
    class purchaseBLL   
    {
        public int id { get; set; }
        public int supid { get; set; }
        public string products { get; set; }
        public decimal grandtotal { get; set; }
        public decimal gst { get; set; }
        public decimal discount { get; set; }
        public DateTime purchasedate { get; set; }

        public DataTable purchasedetails { get; set; }
    }
}
