using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Reservation
    {
        public int IdReservation { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }

        public override string ToString()
        {
            return "IdReservation: " + IdReservation +
                    "DateStart: " + DateStart +
                    "DateEnd: " + DateEnd +
                    "Name: " + Name +
                    "FirstName: " + FirstName;
        }
    }
}
