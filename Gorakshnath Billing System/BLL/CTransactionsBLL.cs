using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gorakshnath_Billing_System.BLL
{
    class CTransactionsBLL
    {
		public int Transaction_ID { get; set; }
		public string Purchase_Type { get; set; }
        public int Customer_ID { get; set; }
        public decimal Discount { get; set; }
        public decimal Total_SGST_Amt { get; set; }
        public decimal Total_CGST_Amt { get; set; }
        public decimal Grand_Total { get; set; }
        public DateTime Tr_Date { get; set; }
        public int MyProperty { get; set; }
    }
}
