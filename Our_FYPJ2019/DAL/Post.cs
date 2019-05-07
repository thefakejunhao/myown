using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Our_FYPJ2019.DAL
{
    public class post
    {
        public post()
        {

        }

        public string username { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string itemname { get; set; }
        public string rtype { get; set; }
        public string ptype { get; set; }
        public string plastic { get; set; }
        public string paper { get; set; }
        public string metal { get; set; }
        public string batteries { get; set; }
        public string electronics { get; set; }
        public string unit { get; set; }
        public string weight { get; set; }
        public string desc { get; set; }
        public string address { get; set; }
        public string image1 { get; set; }
        public string image2 { get; set; }
        public string image3 { get; set; }
        public string image4 { get; set; }
        public string unitno { get; set; }
        public string postalcode { get; set; }
        public string qty { get; set; }
        public int lat { get; set; }
        public int lng { get; set; }
        public string status { get; set; }
    }
}