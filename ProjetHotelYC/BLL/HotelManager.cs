using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public static class HotelManager
    {
        public static List<Hotel> GetAllHotels()
        {
            return HotelDB.GetAllHotels();
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
