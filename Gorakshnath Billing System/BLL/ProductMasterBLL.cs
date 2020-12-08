using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gorakshnath_Billing_System.BLL
{
    class ProductMasterBLL
    {
        public int Product_ID { get; set; }
        public string Product_Group { get; set; }
        public string Brand { get; set; }
        public string Item_Code { get; set; }
        public string Product_Name { get; set; }
        public string HSN_Code { get; set; }
        public decimal Purchase_Price { get; set; }
        public decimal Sales_Price { get; set; }
        public decimal Min_Sales_Price { get; set; }
        public string Unit { get; set; }
        public decimal Quantity { get; set; }
        public decimal Opening_Stock { get; set; }
        public DateTime Added_Date { get; set; }
    }
}
