using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
   public class LinkRoomReservationManager
    {
        public static List<LinkRoomReservation> GetAllLinkRoomReservation()
        {
           return LinkRoomReservationDB.GetAllLinkRoomReservation();
        }

        //écrit dans LinkRoomReservation lors d'un ajout de réservation
        public static int AddLinkRoomReservation(Decimal PriceRoom,int IdReservation, int IdRoom)
        {
            return LinkRoomReservationDB.AddLinkRoomReservation(PriceRoom, IdReservation, IdRoom);
        }

        public static int DeleteLinkRoomReservation(int IdLinkRoomReservation)
        {
            return LinkRoomReservationDB.DeleteLinkRoomReservation(IdLinkRoomReservation);
        }

        //Renvoie les ids des chambres occupées selon une liste d'id de réservation
        public static List<int> GetBusyRooms(List<int> IdActiveReservations)
        {
            List<int> IdBusyRooms = new List<int>();
            List<LinkRoomReservation> LinkRoomReservations = LinkRoomReservationDB.GetAllLinkRoomReservation();

            foreach (LinkRoomReservation lrr in LinkRoomReservations)
            {
                if (IdActiveReservations.Contains(lrr.IdReservation))
                    IdBusyRooms.Add(lrr.IdRoom);
            }

            return IdBusyRooms;
        }

        public static decimal GetPrice(int IdReservation)
        {
            decimal price=0;

            List < LinkRoomReservation > lrr = BLL.LinkRoomReservationManager.GetAllLinkRoomReservation();

            foreach(LinkRoomReservation l in lrr)
            {
                if (l.IdReservation == IdReservation)
                    price = l.PriceRoom;
            }

            return price;
        }

        public static List<int> GetReservationRoomsId(int IdReservation)
        {
            List<int> ListIdRoom = new List<int>();
            List<LinkRoomReservation> AllLrr = BLL.LinkRoomReservationManager.GetAllLinkRoomReservation();

            foreach(LinkRoomReservation lrr in AllLrr)
            {
                if (lrr.IdReservation == IdReservation)
                    ListIdRoom.Add(lrr.IdRoom);
            }

            return ListIdRoom;
        }
    }
}
