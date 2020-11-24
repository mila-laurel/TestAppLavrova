using System;
using System.Collections.Generic;
using System.Xml;

namespace TestAppLavrova.Logic
{
    public class Offer
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int? Bid { get; set; }
        public int? Cbid { get; set; }
        public bool Available { get; set; }
        public List<OfferData> Data { get; set; }

        public Offer()
        {
            Data = new List<OfferData>();
        }
    }
}
