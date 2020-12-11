using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gorakshnath_Billing_System.BLL
{
    class ChallanReturnBLL
    {
        //jhjhjhj
        public string Transaction_Type { get; set; }
        public int Invoice_No { get; set; }
        public int Cust_ID { get; set; }
        public decimal Sub_Total { get; set; }
        public decimal TDiscount { get; set; }
        public decimal TSGST { get; set; }
        public decimal TCGST { get; set; }
        public decimal TIGST { get; set; }
        public decimal Grand_Total { get; set; }
        public DateTime Transaction_Date { get; set; }

        public DataTable SalesDetails { get; set; }

        public int ID { get; set; }
        
        public int Product_ID { get; set; }        
        public string Product_Name { get; set; }
        public string Unit { get; set; }
        public decimal Qty { get; set; }
        public decimal Rate { get; set; }
        public decimal Discount_Per { get; set; }
        public string GST_Type { get; set; }
        public decimal GST_Per { get; set; }
        public decimal Total { get; set; }


    }
}
