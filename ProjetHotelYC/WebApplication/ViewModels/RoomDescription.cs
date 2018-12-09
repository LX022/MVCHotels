using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.ViewModels
{
    public class RoomDescription
    {
        public int IdRoom { get; set; }
        public List<string> Url { get; set; }

        public string description { get; set; }

        public RoomDescription()
        {
            Url = new List<string>();
        }
    }
}