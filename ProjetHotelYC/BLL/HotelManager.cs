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
    // Affichage de tous les hôtels API
    public static class HotelManager
    {
       static string hotelsurl = "http://localhost:3749/api/Hotels/";
        public static List<Hotel> GetAllHotels()
        {
            List<Hotel> hotels;
            
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(hotelsurl);
                hotels = JsonConvert.DeserializeObject<List<Hotel>>(response.Result);
            }
            return hotels;
        }

        // Affichage d'un hôtel API
        public static Hotel GetHotel(int IdHotel)
        {
            string hotelurl = hotelsurl + IdHotel;

            using (HttpClient client = new HttpClient())
            {

                Task<string> response = client.GetStringAsync(hotelurl);
                return JsonConvert.DeserializeObject<Hotel>(response.Result);
            }
        }

        //méthode pour la recherche avancée API
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
