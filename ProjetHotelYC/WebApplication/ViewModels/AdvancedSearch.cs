using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.ViewModels
{
    public class AdvancedSearch
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Location { get; set; }
        public int CategoryLow { get; set; }
        public int Categoryhigh { get; set; }
        public Boolean HasWifi { get; set; }
        public Boolean HasParking { get; set; }
        public int Type { get; set; }
        public decimal PriceLow { get; set; }
        public decimal PriceHigh { get; set; }
        public Boolean HasTV { get; set; }
        public Boolean HasHairDryer { get; set; }

    }
}