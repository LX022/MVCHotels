using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO;

namespace WebApplication.ViewModels
{
    public class Recu
    {
        public int IdReservation { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public List<Room> rooms { get; set; }
        public decimal price { get; set; }

        public Recu()
        {
            List < Room > rooms= new List<Room>();
        }
    }

}