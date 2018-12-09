using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using DTO;

namespace WebApplication.Controllers
{
    public class HotelController : Controller
    {
        // GET: Hotel
        public ActionResult Informations(int id)
        {
            var hotel = BLL.HotelManager.GetHotel(id);

            return View(hotel);
        }
    }
}