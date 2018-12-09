using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BLL;
using DTO;
using Newtonsoft.Json;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {


            var hotels = BLL.HotelManager.GetAllHotels();

            return View(hotels);
        }

    }
}