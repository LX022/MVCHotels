using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DTO;
using System.Net.Http;
using Newtonsoft.Json;

namespace BLL
{
    public class RoomManager
    {
        static string roomsURL = "http://localhost:3749/api/Rooms/";
        // Liste des chambres API
        public static List<Room> GetAllRooms()
        {
            List<Room> Rooms;

            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(roomsURL);
                Rooms = JsonConvert.DeserializeObject<List<Room>>(response.Result);
            }
            return Rooms;
        }

        //Renvoie la liste de chambre libre API
        public static List<Room> GetAvailableRooms(List<int> IdBusyRooms)
        {
            List<Room> AllRooms = RoomManager.GetAllRooms();
            List<Room> AvailableRoom = new List<Room>();

            foreach (Room r in AllRooms)
            {
                if (IdBusyRooms.Contains(r.IdRoom))
                {

                }
                    else
                    AvailableRoom.Add(r);
            }

            return AvailableRoom;
        }
        //Renvoie la liste de chambres libre selon date et emplacement
        public static List<Room> ShowAvailableRooms (String Location, DateTime Start, DateTime End)
        {
            List<Room> HotelsRooms = new List<Room>();
            List<int>idHotels = new List<int>();

            List<Hotel> Hotels = BLL.HotelManager.GetAllHotels();
            List<Room> Rooms = BLL.RoomManager.GetAvailableRooms(BLL.LinkRoomReservationManager.GetBusyRooms(BLL.ReservationManager.GetActiveReservations(Start, End)));

            foreach (Hotel h in Hotels)
            {
                if (h.Location==Location)
                    idHotels.Add(h.IdHotel);
            }

            foreach(Room r in Rooms)
            {
                if (idHotels.Contains(r.IdHotel))
                    HotelsRooms.Add(r);
            }


            return HotelsRooms;
        }

        public static Room GetRoom(int IdRoom)
        {
            string hotelurl = roomsURL + IdRoom;

            using (HttpClient client = new HttpClient())
            {

                Task<string> response = client.GetStringAsync(hotelurl);
                return JsonConvert.DeserializeObject<Room>(response.Result);
            }
        }
        //Renvoie la liste de chambres libre selon les critères de recherche avancé sans type
        public static List<Room>ShowAvailableRoomsAdvanced(decimal PriceLow, decimal PriceHigh, Boolean HasTv, Boolean HasHairDryer, DateTime Start, DateTime End)
        {
            List<Room> HotelsRooms = new List<Room>();

            List<Room> Rooms = BLL.RoomManager.GetAvailableRooms(BLL.LinkRoomReservationManager.GetBusyRooms(BLL.ReservationManager.GetActiveReservations(Start, End)));

            foreach (Room r in Rooms)
            {
                if ((r.Price >= PriceLow && r.Price <= PriceHigh) && r.HasTV==HasTv && r.HasHairDryer == HasHairDryer)
                    HotelsRooms.Add(r);
            }
            return (HotelsRooms);
        }
        //Renvoie la liste de chambres libre selon les critères de recherche avancé avec type
        public static List<Room> ShowAvailableRoomsAdvancedType(int Type, decimal PriceLow, decimal PriceHigh, Boolean HasTv, Boolean HasHairDryer, DateTime Start, DateTime End)
        {
            List<Room> HotelsRooms = new List<Room>();

            List<Room> Rooms = BLL.RoomManager.GetAvailableRooms(BLL.LinkRoomReservationManager.GetBusyRooms(BLL.ReservationManager.GetActiveReservations(Start, End)));

            foreach (Room r in Rooms)
            {
                if (r.Type==Type && (r.Price >= PriceLow && r.Price <= PriceHigh) && r.HasTV == HasTv && r.HasHairDryer == HasHairDryer)
                    HotelsRooms.Add(r);
            }
            return (HotelsRooms);
        }
        //Combine les deux recherche pour la recherche avancée définitive
        public static List<Room>AdvancedSearch(int Type, decimal PriceLow, decimal PriceHigh, Boolean HasTv, Boolean HasHairDryer, DateTime Start, DateTime End, string Location, int CategoryLow, int CategoryHigh, Boolean HasWifi, Boolean HasParking)
        {
            List<Room> RoomAdvancedSearch = new List<Room>();
            List<Room> R;
            List<int> idHotels = BLL.HotelManager.ShowAvailablesHotelsAdvanced(Location, CategoryLow, CategoryHigh, HasWifi, HasParking);

            if (Type == 3)
            { 
           R= BLL.RoomManager.ShowAvailableRoomsAdvanced(PriceLow, PriceHigh, HasTv, HasHairDryer, Start, End);
            }else
                R = BLL.RoomManager.ShowAvailableRoomsAdvancedType(Type, PriceLow, PriceHigh, HasTv, HasHairDryer, Start, End);


            foreach (Room room in R)
            {
                if (idHotels.Contains(room.IdHotel))
                    RoomAdvancedSearch.Add(room);
            }
                

            return (RoomAdvancedSearch);
        }
        //Renvoie la liste des chambres pour le reçu
        public static List<Room> RoomRecu(int id)
        {
            List<int> idLrr = BLL.LinkRoomReservationManager.GetReservationRoomsId(id);

            List<Room> AllRooms = BLL.RoomManager.GetAllRooms();

            List<Room> rooms = new List<Room>();

            foreach (Room r in AllRooms)
            {
                if (idLrr.Contains(r.IdRoom))
                    rooms.Add(r);
            }

            return (rooms);
        }
    }
}
