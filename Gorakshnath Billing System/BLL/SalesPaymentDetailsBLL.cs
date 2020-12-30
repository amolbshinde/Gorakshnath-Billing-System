using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gorakshnath_Billing_System.BLL
{
    class SalesPaymentDetailsBLL
    {

        public int PaymentId { get; set; }
        public int Invoice_No { get; set; }
        public string TrMode { get; set; }
        public string PaymentMode { get; set; }
        public string Remarks { get; set; }        
        public decimal TrAmount { get; set; }
        public decimal AmountPiad { get; set; }
        public decimal Balance { get; set; }
    }
}
