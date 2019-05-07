using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Our_FYPJ2019.DAL
{

    [Serializable]

    public class Listitems {
        public string username { get; set; }
        public int itemid { get; set; }
        public string price { get; set; }
        public string itemname { get; set; }
        public string rtype { get; set; }
        public string unit { get; set; }
        public string weight { get; set; }
        public string desc { get; set; }
        public string image1 { get; set; }
        public string date { get; set; }
        public string profile { get; set; }
        public string qty { get; set; }
        public string address { get; set; }
        public string postalcode { get; set; }
        public string unitno { get; set; }
        public string estate { get; set; }

    }

}