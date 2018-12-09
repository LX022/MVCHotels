using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LinkRoomReservation
    {
        public int IdLinkRoomReservation { get; set; }
        public decimal PriceRoom {get; set; }
        public int IdReservation { get; set; }
        public int IdRoom { get; set; }

        public override string ToString()
        {
            return "IdLinkRoomReservation: " + IdLinkRoomReservation +
                    "PriceRoom: " + PriceRoom +
                    "IdReservation: " + IdReservation +
                    "IdRoom: " + IdRoom;
        }

    }
}
