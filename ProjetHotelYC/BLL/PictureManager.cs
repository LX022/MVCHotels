using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;


namespace BLL
{
    public class PictureManager
    {
        public static List<Picture> GetPictures(int IdRoom)
        {
            return PictureDB.GetPictures(IdRoom);
        }
    }
}
