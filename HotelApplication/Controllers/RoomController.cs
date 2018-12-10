using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelApplication.Models;

namespace HotelApplication.Controllers
{
    public class RoomController : Controller
    {
        // GET: Rooms
        public ActionResult Index()
        {
            return View();
        }
    }
}