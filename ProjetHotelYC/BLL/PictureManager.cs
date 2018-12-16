using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DTO;
using System.Net.Http;
using Newtonsoft.Json;

namespace BLL
{
    public class PictureManager
    {
        static string picturesURL = "http://localhost:3749/api/Pictures/";

        // Affichage des photos API
        public static List<Picture> GetPictures(int IdRoom)
        {
            List<Picture> pictures;
            List<Picture> roomPictures = new List<Picture>();

            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(picturesURL);
                pictures = JsonConvert.DeserializeObject<List<Picture>>(response.Result);
            }

            foreach(Picture p in pictures)
            {
                if (p.IdRoom.Equals(IdRoom))
                {
                    roomPictures.Add(p);
                }
            }

            return roomPictures;
        }
    }
}
