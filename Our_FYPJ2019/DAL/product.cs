using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Our_FYPJ2019.DAL
{
    [Serializable]
    public class product
    {
        public string username { get; set; }
        public int id { get; set; }
        public string price { get; set; }
        public string itemname { get; set; }
        public string rtype { get; set; }
        public string unit { get; set; }
        public string weight { get; set; }
        public string desc { get; set; }
        public string image1 { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string plastic { get; set; }
        public string ptype { get; set; }
        public string paper { get; set; }
        public string metal { get; set; }
        public string batteries{ get; set; }
        public string electronics { get; set; }
        public string image2 { get; set; }
        public string image3 { get; set; }
        public string image4 { get; set; }
        public string unitno { get; set; }
        public string postalcode { get; set; }
        public string address { get; set; }
        public string qty { get; set; }
        public string district { get; set; }
        public string estate { get; set; }
        public string buyerres { get; set; }
        public string buyeraccept { get; set; }
        public string collectiondate { get; set; }
        public string timeslot { get; set; }
        //Quotation
        public string buyer { get; set; }
        public string item { get; set; }
        public string itemid { get; set; }
        public string seller { get; set; }
        public string msg { get; set; }
        public string coverimg { get; set; }
        public string status { get; set; }
        public int quoteid { get; set; }
        public string reason { get; set; }
        public string reasondesc { get; set; }
        public string bres { get; set; }
        public string sres { get; set; }
        public string sellerdate { get; set; }
       
    }
}