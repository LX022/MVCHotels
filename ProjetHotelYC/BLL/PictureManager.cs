using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(picturesURL);
                pictures = JsonConvert.DeserializeObject<List<Picture>>(response.Result);
            }
            return pictures;
        }
    }
}
