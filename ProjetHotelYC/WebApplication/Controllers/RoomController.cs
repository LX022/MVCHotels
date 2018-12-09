using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using DTO;

namespace WebApplication.Controllers
{
    public class RoomController : Controller
    {
        //Envoie les chambres disponible selon la recherche simple
        [HttpPost]
        public ActionResult ChooseRoom(string Location, DateTime Start, DateTime End, string Name, string FirstName)
        {
            // Si les dates ont été mise à l'envers par l'utilisateur, je les remets à l'endroit
            DateTime temp;

            if (Start > End)
            {
                temp = End;
                End = Start;
                Start = temp;
            }

            List<Room> rooms = BLL.RoomManager.ShowAvailableRooms(Location, Start, End);

            var listRooms = new List<SelectListItem>();

            foreach(Room r in rooms)
            {
                SelectListItem item = new SelectListItem();
                item.Value = r.IdRoom.ToString();
                item.Value = r.Number.ToString();
                listRooms.Add(item);
            }

            ViewBag.ListRooms = listRooms;

            Models.Panier reservation = new Models.Panier();
            reservation.Start = Start;
            reservation.End = End;
            reservation.Location = Location;
            reservation.Name = Name;
            reservation.Firstname = FirstName;
            Session["Panier"] = reservation;

            return View(rooms);
        }

        //Envoi les chambres disponibles selon la recherche avancée
        [HttpPost]
        public ActionResult ChooseRoomAdvanced(DateTime Start, DateTime End, string Location, string CategoryLow, string CategoryHigh, string HasWifi, string HasParking, string Type, string PriceLow, string PriceHigh, string HasTV, string HasHairDryer, string Name, string FirstName)
        {
            int CategoryLowInt = Convert.ToInt32(CategoryLow);
            int CategoryHighInt = Convert.ToInt32(CategoryHigh);
            Boolean HasWifiBoolean = Convert.ToBoolean(HasWifi);
            Boolean HasParkingBoolean = Convert.ToBoolean(HasParking);
            int TypeInt = Convert.ToInt32(Type);
            decimal PriceLowDecimal = Convert.ToDecimal(PriceLow);
            decimal PriceHighDecimal = Convert.ToDecimal(PriceHigh);
            Boolean HasTVBoolean = Convert.ToBoolean(HasTV);
            Boolean HasHairDryerBoolean = Convert.ToBoolean(HasHairDryer);

            // Si les dates ont été mise à l'envers par l'utilisateur, je les remets à l'endroit
            DateTime temp;

            if (Start > End)
            {
                temp = End;
                End = Start;
                Start = temp;
            }

            Models.Panier reservation = new Models.Panier();
            reservation.Start = Start;
            reservation.End = End;
            reservation.Location = Location;
            reservation.Name = Name;
            reservation.Firstname = FirstName;
            reservation.CategoryHigh = CategoryHighInt;
            reservation.CategoryLow = CategoryLowInt;
            reservation.HasWifi = HasWifiBoolean;
            reservation.HasParking = HasParkingBoolean;
            reservation.Type = TypeInt;
            reservation.PriceLow = PriceLowDecimal;
            reservation.PriceHigh = PriceHighDecimal;
            reservation.HasTV = HasTVBoolean;
            reservation.HasHairDryer = HasHairDryerBoolean;
            Session["Panier"] = reservation;

            List<Room> rooms = BLL.RoomManager.AdvancedSearch(TypeInt, PriceLowDecimal, PriceHighDecimal,HasTVBoolean,HasHairDryerBoolean,Start, End, Location, CategoryLowInt, CategoryHighInt, HasWifiBoolean, HasParkingBoolean);

            return View(rooms);
        }

        public ActionResult DescriptionChambre(int id)
        {
            ViewModels.RoomDescription roomDescription = new ViewModels.RoomDescription();
            Room r = BLL.RoomManager.GetRoom(id);
            List<Picture> pics = BLL.PictureManager.GetPictures(id);


            roomDescription.IdRoom = id;
            roomDescription.description = r.Description;

            foreach (Picture p in pics)
            {
                roomDescription.Url.Add(p.Url);
            }
            return View(roomDescription);
        }
    }
}