﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Room
    {
        public int IdRoom { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public decimal Price{ get; set; }
        public Boolean HasTV { get; set; }
        public Boolean HasHairDryer { get; set; }
        public int IdHotel { get; set; }

        public override string ToString()
        {
            return "IdRoom: " + IdRoom +
                    "Number: " + Number +
                    "Description: " + Description +
                    "Type: " + Type +
                    "Price: " + Price +
                    "HasTV: " + HasTV +
                    "HasHairDryer: " + HasHairDryer +
                    "IdHotel: " + IdHotel;
        }

    }
}
