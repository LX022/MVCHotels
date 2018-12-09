using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO;

namespace WebApplication.ViewModels
{
    public class SimpleSearchResult
    {
        public List<Room> rooms { get; set; }
        public List<Room>roomsSelected { get; set; }

        public SimpleSearchResult(List<Room> rooms)
        {

            if (rooms != null)
            {
                rooms = new List<Room>();
            }

            foreach (Room r in rooms)
            {

            }

        }
    }
}