using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using DTO;
using System.Collections;

namespace WebApplication.Controllers
{
    public class ReservationController : Controller
    {
        // GET: Reservation

        //lance la recherche basique
        public ActionResult Reserver(int id)
        {
            ViewModels.DatesReservationVM Dates = new ViewModels.DatesReservationVM();

            return View(Dates);
        }
        //lance la recherche avancée
        public ActionResult AdvancedSearch()
        {
            ViewModels.AdvancedSearch Advanced = new ViewModels.AdvancedSearch();
            return View(Advanced);
        }

        //Met la chambre dans le panier et inscrit la reservation dans la bd et lance le reçu
        public ActionResult EndReservationSimple(int id)
        {

            List<Room> room = new List<Room>();
            List<Room> Rooms = BLL.RoomManager.GetAllRooms();
            decimal price = 0;

            Models.Panier reservation = (Models.Panier)this.Session["Panier"];

            foreach (Room c in Rooms)
            {
                if (c.IdRoom == id)
                    room.Add(c);
            }


            BLL.ReservationManager.CreatReservation(room, reservation.Start, reservation.End,reservation.Name,reservation.Firstname);

            ViewModels.Recu r = new ViewModels.Recu();
            r.FirstName = reservation.Firstname;
            r.Name = reservation.Name;
            r.Start = reservation.Start;
            r.End = reservation.End;
           

            List<Reservation> AllReservations = BLL.ReservationManager.GetAllReservations();

            foreach(Reservation res in AllReservations)
            {
                if (res.FirstName == reservation.Firstname && res.Name == reservation.Name && res.DateStart == reservation.Start && res.DateEnd == reservation.End)
                    r.IdReservation = res.IdReservation;
            }

            List<LinkRoomReservation> AllLRR = BLL.LinkRoomReservationManager.GetAllLinkRoomReservation();

            foreach (LinkRoomReservation lrr in AllLRR)
            {
                if (lrr.IdReservation == r.IdReservation)
                    price += lrr.PriceRoom;
            }

            r.price = price;
            r.rooms = BLL.RoomManager.RoomRecu(r.IdReservation);

            return View(r);
        }

        //Ajoute les chambres dans le panier
        public ActionResult AddPanier(int id)
        {
            Models.Panier reservation = (Models.Panier)this.Session["Panier"];

            reservation.ids.Add(id);

            List<Room> Oldroom = new List<Room>();
            List<Room> Newroom = new List<Room>();

            Oldroom = BLL.RoomManager.ShowAvailableRooms(reservation.Location, reservation.Start, reservation.End);

            foreach(Room r in Oldroom)
            {
                if (reservation.ids.Contains(r.IdRoom))
                {

                }
                else
                    Newroom.Add(r);

            }

            return View(Newroom);
        }

        //Ajoute les chambres dans le panier via la recherche avancée
        public ActionResult AddPanierAdvanced(int id)
        {
            Models.Panier reservation = (Models.Panier)this.Session["Panier"];

            reservation.ids.Add(id);

            List<Room> Oldroom = new List<Room>();
            List<Room> Newroom = new List<Room>();

            Oldroom = BLL.RoomManager.AdvancedSearch(reservation.Type,reservation.PriceLow, reservation.PriceHigh,reservation.HasTV,reservation.HasHairDryer,reservation.Start,reservation.End,reservation.Location,reservation.CategoryLow,reservation.CategoryHigh,reservation.HasWifi,reservation.HasParking);

            foreach (Room r in Oldroom)
            {
                if (reservation.ids.Contains(r.IdRoom))
                {

                }
                else
                    Newroom.Add(r);

            }

            return View(Newroom);
        }

        //Inscrit la reservation via le panier dans la bd
        public ActionResult Confirmer()
        {
            Models.Panier reservation = (Models.Panier)this.Session["Panier"];
            decimal price = 0;
            List<Room> rs = new List<Room>();
            List<Room> all = BLL.RoomManager.GetAllRooms();

            foreach(Room room in all)
            {
                if (reservation.ids.Contains(room.IdRoom))
                    rs.Add(room);
            }

            BLL.ReservationManager.CreatReservation(rs, reservation.Start, reservation.End, reservation.Name, reservation.Firstname);

            ViewModels.Recu r = new ViewModels.Recu();
            r.FirstName = reservation.Firstname;
            r.Name = reservation.Name;
            r.Start = reservation.Start;
            r.End = reservation.End;

            List<Reservation> AllReservations = BLL.ReservationManager.GetAllReservations();

            foreach (Reservation res in AllReservations)
            {
                if (res.FirstName == reservation.Firstname && res.Name == reservation.Name && res.DateStart == reservation.Start && res.DateEnd == reservation.End)
                    r.IdReservation = res.IdReservation;
            }

            List<LinkRoomReservation> AllLRR = BLL.LinkRoomReservationManager.GetAllLinkRoomReservation();

            foreach (LinkRoomReservation lrr in AllLRR)
            {
                if (lrr.IdReservation == r.IdReservation)
                    price += lrr.PriceRoom;
            }

            r.price = price;
            r.rooms = BLL.RoomManager.RoomRecu(r.IdReservation);

            return View(r);
        }

        //Lance la vue pour rechercher une reservation
        public ActionResult SearchReservation()
        {
            ViewModels.SearchReservation search = new ViewModels.SearchReservation();

            return View(search);
        }

        //Recherche la reservation
        [HttpPost]
        public ActionResult ShowReservation(int IdReservation, string Name, string FirstName)
        {
            int IdReservationInt = Convert.ToInt32(IdReservation);

            decimal price=0;

            List<Reservation> AllReservations = BLL.ReservationManager.GetAllReservations();
            ViewModels.Recu r = new ViewModels.Recu();

            List<LinkRoomReservation> AllLRR =BLL.LinkRoomReservationManager.GetAllLinkRoomReservation();

            foreach(LinkRoomReservation lrr in AllLRR)
            {
                if (lrr.IdReservation == IdReservation)
                    price += lrr.PriceRoom;
            }

            foreach (Reservation res in AllReservations)
            {
                if (res.FirstName == FirstName && res.Name == Name && res.IdReservation == IdReservation)
                {
                    r.FirstName = FirstName;
                    r.Name = Name;
                    r.price = price;
                    r.IdReservation = IdReservation;
                    r.Start = BLL.ReservationManager.GetStart(IdReservation);
                    r.End = BLL.ReservationManager.GetEnd(IdReservation);
                    r.rooms = BLL.RoomManager.RoomRecu(IdReservation);
                }
            }

            return View(r);
        }
        //Supprime une reservation
        public ActionResult DeleteReservation(int id)
        {

            List<LinkRoomReservation> all = BLL.LinkRoomReservationManager.GetAllLinkRoomReservation();

            foreach(LinkRoomReservation lrr in all)
            {
                if (lrr.IdReservation == id)
                    BLL.LinkRoomReservationManager.DeleteLinkRoomReservation(lrr.IdLinkRoomReservation);
            }

            BLL.ReservationManager.DeleteReservation(id);

            return View();
        }
    }
}