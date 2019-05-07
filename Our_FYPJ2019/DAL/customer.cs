using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFYPJBackup.DAL
{
    public class customer
    {
        public string NRIC { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string HomeNo { get; set; }
        public string Email { get; set; }
        public string Area { get; set; }
        public string reason { get; set; }
        public string reportBy { get; set; }
        public string type { get; set; }
        public string reasonStated { get; set; }
        public string listingID { get; set; }
        public string itemName { get; set; }
        public string reportID { get; set; }
        public string adminBan { get; set; }
        public string date { get; set;}
        public string noOfReports { get; set; }

        public string unitNo { get; set; }

        //object same name as database


    }
}