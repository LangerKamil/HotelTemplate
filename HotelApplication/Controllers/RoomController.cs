using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelApplication.Models;
using HotelApplication.ViewModels;
using AutoMapper;

namespace HotelApplication.Controllers
{
    public class RoomController : Controller
    {
        private ApplicationDbContext _context;

        public RoomController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Rooms
        public ActionResult Index()
        {
            return View();
        }

        //[HttpPut]
        public ActionResult RoomDetails(int id)
        {
            var room = _context.Rooms.SingleOrDefault(c => c.Id == id);

            if (room == null)
                return HttpNotFound();

            var rmStatus = _context.RoomStatus.ToList();
            var rmType = _context.RoomTypes.ToList();

            var viewModel = new RoomFormViewModel
            {
                Room = room,
                RoomTypes = _context.RoomTypes.ToList(),
                RoomStatuses = _context.RoomStatus.ToList(),
            };

            return View(viewModel);
        }


        [HttpPost]
        public ActionResult Edit(Room room)
        {
            
            var roomInDb = _context.Rooms.SingleOrDefault(c => c.Id == room.Id);

            Mapper.Map(room, roomInDb);

            _context.SaveChanges();

            return RedirectToAction("Rooms", "Service");
        }

        [HttpPost]
        [Route("calendar/PostCalendarData")]
        public ActionResult PostCalendarData()
        {
            return Json(new { title = "Free Pizza", allday = "false", borderColor = "#5173DA", color = "#99ABEA", textColor = "#000000", description = "<p>This is just a fake description for the Free Pizza.</p><p>Nothing to see!</p>", start = "2015-01-04T22:00:49", end = "2015-01-01", url = "http=//www.mikesmithdev.com/blog/worst-job-titles-in-internet-and-info-tech/" });
        }

        [HttpGet]
        [Route("calendar/GetCalendarData")]
        public ActionResult GetCalendarData()
        {
            return Json(new { title = "Free Pizza", allday = "false", borderColor = "#5173DA", color = "#99ABEA", textColor = "#000000", description = "<p>This is just a fake description for the Free Pizza.</p><p>Nothing to see!</p>", start = "2015-01-04T22:00:49", end = "2015-01-01", url = "http=//www.mikesmithdev.com/blog/worst-job-titles-in-internet-and-info-tech/" }, JsonRequestBehavior.AllowGet);
        }
    }
}