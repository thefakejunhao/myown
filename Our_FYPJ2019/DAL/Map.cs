using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Our_FYPJ2019.DAL
{
    public class Map
    {
        public Map() { }

        public string username { get; set; }
        public int id { get; set; }
        public string itemname { get; set; }
        public string rtype { get; set; }
        public string image1 { get; set; }
        public string address { get; set; }
        public string unitno { get; set; }
        public string PostalCode { get; set; }
        public string estate { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double distance { get; set; }
    }
}