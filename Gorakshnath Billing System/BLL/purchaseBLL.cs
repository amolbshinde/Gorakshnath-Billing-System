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
        public int id { get; set; }
        public string type { get; set; }
        public int supid { get; set; }
        public decimal subTotal { get; set; }
        public decimal totalDiscount { get; set; }
        public decimal totalSgst { get; set; }
        public decimal totalCgst { get; set; }
        public decimal totalIgst { get; set; }
        public decimal grandTotal { get; set; }
        public DateTime purchasedate { get; set; }

        public DataTable purchasedetails { get; set; }
    }
}
