using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;


namespace BLL
{
   public class ReservationManager
    {
        public static Reservation GetReservation(int IdReservation)
        {
            return ReservationDB.GetReservation(IdReservation);
        }

        public static List<Reservation> GetAllReservations()
        {
            return ReservationDB.GetAllReservations();
        }

        //Ecrit dans la bd lors de la création d'une réservation
        public static void CreatReservation(List<Room> Rooms, DateTime DateStart, DateTime DateEnd, string Name, string FirstName)
        {
            TimeSpan NbDays;

            NbDays = DateEnd - DateStart;

           var IdReservation = DAL.ReservationDB.AddReservation(DateStart, DateEnd, Name, FirstName);

            foreach (Room room in Rooms)
            {
                decimal PriceRoom;

                PriceRoom = room.Price * NbDays.Days;

                DAL.LinkRoomReservationDB.AddLinkRoomReservation(PriceRoom, IdReservation, room.IdRoom);
            };

        }

        public static int DeleteReservation(int IdReservation)
        {
            return ReservationDB.DeleteReservation(IdReservation);
        }

        //Trouve les reservations existantes selon dates
        public static List<int> GetActiveReservations(DateTime DateStart, DateTime DateEnd)
        {
            List<int> IdActiveReservations= new List<int>();
            List<Reservation> AllReservations;

            AllReservations = BLL.ReservationManager.GetAllReservations();

            foreach(Reservation reservations in AllReservations)
            {
                if ((DateStart >= reservations.DateStart && DateStart < reservations.DateEnd) || (DateEnd > reservations.DateStart && DateEnd  <reservations.DateEnd)  ||(DateStart < reservations.DateStart && DateEnd > reservations.DateEnd))
                    IdActiveReservations.Add(reservations.IdReservation);
            }
                return IdActiveReservations;
        }

        public static void CreatSimpleReservation(Room r, DateTime DateStart, DateTime DateEnd, string Name, string FirstName)
        {
            TimeSpan NbDays;

            NbDays = DateEnd - DateStart;

            var IdReservation = DAL.ReservationDB.AddReservation(DateStart, DateEnd, Name, FirstName);



            decimal PriceRoom;

                PriceRoom = r.Price * NbDays.Days;

                DAL.LinkRoomReservationDB.AddLinkRoomReservation(PriceRoom, IdReservation, r.IdRoom);

        }
        //Renvoie la date d'arrivée pour le reçu
        public static DateTime GetStart(int IdReservation)
        {
            DateTime start= new DateTime();

            List<Reservation> res = BLL.ReservationManager.GetAllReservations();

            foreach (Reservation r in res)
            {
                if (r.IdReservation == IdReservation)
                    start = r.DateStart;
            }

            return start;
        }
        //Renvoie la date de départ pour le reçu
        public static DateTime GetEnd(int IdReservation)
        {
            DateTime end = new DateTime();

            List<Reservation> res = BLL.ReservationManager.GetAllReservations();

            foreach (Reservation r in res)
            {
                if (r.IdReservation == IdReservation)
                    end = r.DateEnd;
            }

            return end;
        }
    }
}
