using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO;

namespace WebApplication.Models
{
    public class Panier
    {
        public List<int> ids { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Name { get; set; }
        public string Firstname { get; set; }
        public string Location { get; set; }

        public int CategoryLow { get; set; }
        public int CategoryHigh { get; set; }
        public Boolean HasWifi { get; set; }
        public Boolean HasParking { get; set; }
        public int Type { get; set; }
        public decimal PriceLow { get; set; }
        public decimal PriceHigh { get; set; }
        public Boolean HasTV { get; set; }
        public Boolean HasHairDryer { get; set; }



        public Panier()
        {
            ids = new List<int>();
        }
    }
}