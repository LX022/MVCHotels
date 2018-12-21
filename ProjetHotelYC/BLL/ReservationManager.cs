using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace BLL
{
   public class ReservationManager
    {
        static string reservationURL = "http://localhost:3749/api/Reservations/";
        //Obtenir une réservation API
        public static Reservation GetReservation(int IdReservation)
        {
            string reservationurl = reservationURL + IdReservation;

            using (HttpClient client = new HttpClient())
            {

                Task<string> response = client.GetStringAsync(reservationURL);
                return JsonConvert.DeserializeObject<Reservation>(response.Result);
            }
        }

        //Obtenir toutes les réservations API
        public static List<Reservation> GetAllReservations()
        {
            List<Reservation> reservations;

            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(reservationURL);
                reservations = JsonConvert.DeserializeObject<List<Reservation>>(response.Result);
            }
            return reservations;

        }
        //-------------------------------------------------------------------------------------------------
        //Ecrit dans la bd lors de la création d'une réservation
        public static Boolean CreatReservation(List<Room> Rooms, DateTime DateStart, DateTime DateEnd, string Name, string FirstName)
        {
            TimeSpan NbDays;

            NbDays = DateEnd - DateStart;


            Reservation toAdd = new Reservation(DateStart, DateEnd, Name, FirstName);

            using (HttpClient httpClient = new HttpClient())
            {
                string pro = JsonConvert.SerializeObject(toAdd);
                StringContent frame = new StringContent(pro, Encoding.UTF8, "Application/json");
                Task<HttpResponseMessage> response = httpClient.PostAsync(reservationURL, frame);


                var IdReservationPath = response.Result.Headers.Location.AbsolutePath;
                var IdString = IdReservationPath.Replace("/api/Reservations/", "");
                var IdReservation = Int32.Parse(IdString);

            foreach (Room room in Rooms)
            {
                decimal PriceRoom;

                PriceRoom = room.Price * NbDays.Days;

                LinkRoomReservationManager.AddLinkRoomReservation(PriceRoom, IdReservation, room.IdRoom);
            };
                return response.Result.IsSuccessStatusCode;
            }
        }
        //-------------------------------------------------------------------------------------------------
        public static void DeleteReservation(int IdReservation)
        {
            //return ReservationDB.DeleteReservation(IdReservation);

            String toDelete = reservationURL + IdReservation;

            using (HttpClient httpClient = new HttpClient())
            {

                httpClient.DeleteAsync(toDelete);
               
            }
        }
        //-------------------------------------------------------------------------------------------------

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
        //-------------------------------------------------------------------------------------------------
        public static void CreatSimpleReservation(Room r, DateTime DateStart, DateTime DateEnd, string Name, string FirstName)
        {

            List<Room> rooms= new List<Room>();

            rooms.Add(r);

            CreatReservation(rooms, DateStart,DateEnd,Name,FirstName);

        }
        //-------------------------------------------------------------------------------------------------

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
