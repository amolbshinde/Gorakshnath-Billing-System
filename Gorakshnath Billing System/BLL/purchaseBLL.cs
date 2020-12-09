using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gorakshnath_Billing_System.BLL
{
    class purchaseBLL   
    {
        public string Transaction_Type { get; set; }
        public int Purchase_ID { get; set; }
        public int Sup_ID { get; set; }
        public decimal Sub_Total { get; set; }
        public decimal TDiscount { get; set; }
        public decimal TSGST { get; set; }
        public decimal TCGST { get; set; }
        public decimal TIGST { get; set; }
        public decimal Grand_Total { get; set; }
        public DateTime Purchase_Date { get; set; }

        public DataTable PurchaseDetails { get; set; }
    }
}
