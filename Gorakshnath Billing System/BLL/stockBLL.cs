using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gorakshnath_Billing_System.BLL
{
    class stockBLL
    {

        public int Stock_Id { get; set; }
        public int Product_Id { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
        public DateTime Added_Date { get; set; }

    }
}
