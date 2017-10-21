using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindaHall.Models;
using Microsoft.AspNetCore.Mvc;

namespace FindaHall.Controllers
{
    public class MapController : Controller
    {
        public IActionResult Index(string name, string from, string to)
        {
            MapLocation mapLoc = new MapLocation
            {
                Name=name,
                Lat=111,
                Lan=222
            };
            return View(mapLoc);
        }
      
    }
}