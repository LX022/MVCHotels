using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Net.Http;
using Newtonsoft.Json;

namespace BLL
{
    public static class HotelManager
    {

        public static List<Hotel> GetAllHotels()
        {
            List<Hotel> hotels;
            string uri = "http://localhost:3749/api/Hotels/";
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                hotels = JsonConvert.DeserializeObject<List<Hotel>>(response.Result);
            }
            return hotels;
        }

        public static Hotel GetHotel(int IdHotel)
        {
            return HotelDB.GetHotel(IdHotel);
        }

        //méthode pour la recherche avancée
        public static List<int> ShowAvailablesHotelsAdvanced(string Location, int CategoryLow, int CategoryHigh, Boolean HasWifi, Boolean HasParking)
        {
            List<int> idHotels = new List<int>();
            List<Hotel> Hotels = BLL.HotelManager.GetAllHotels();

            foreach (Hotel h in Hotels)
            {
                if (h.Location==Location&&h.HasWifi==HasWifi&&h.HasParking==HasParking && (h.Category>=CategoryLow&&h.Category<=CategoryHigh))
                    idHotels.Add(h.IdHotel);
            }
            return (idHotels);

        }
    }
}
