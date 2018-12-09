using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO;
using BLL;

namespace WebApplication.ViewModels
{
    public class DatesReservationVM
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int IdHotel { get; set; }
    }
}