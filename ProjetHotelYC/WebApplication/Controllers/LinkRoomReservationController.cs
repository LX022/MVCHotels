using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using DTO;

namespace WebApplication.Controllers
{
    public class LinkRoomReservationController : Controller
    {
        // GET: LinkRoomReservation
        public ActionResult Index()
        {
            return View();
        }
    }
}