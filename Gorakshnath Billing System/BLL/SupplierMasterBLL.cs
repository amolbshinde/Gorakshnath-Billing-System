using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gorakshnath_Billing_System.BLL
{
    class SupplierMasterBLL
    {
        public int SupplierID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone_No { get; set; }
        public string Contact_Person { get; set; }
        public string Contact_No { get; set; }
        public string Gst_No { get; set; }
        public DateTime added_date { get; set; }

    }
}
