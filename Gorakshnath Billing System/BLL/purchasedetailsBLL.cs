using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gorakshnath_Billing_System.BLL
{
    class purchasedetailsBLL
    {
        public int ID { get; set; }
        public int Purchase_ID { get; set; }
        public int Product_ID { get; set; }
        public int Sup_ID { get; set; }
        public string Product_Name { get; set; }
        public string Unit { get; set; }
        public decimal Qty { get; set; }
        public decimal Purchase_Prise { get; set; }
        public decimal Discount_Per { get; set; }
        public string GST_Type { get; set; }
        public decimal GST_Per { get; set; }
        public decimal Total { get; set; }
    }
}
