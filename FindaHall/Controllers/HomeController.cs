using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FindaHall.Models;
using FindaHall.Api_Operations;
using Microsoft.Extensions.Configuration;

namespace FindaHall.Controllers
{
    public class HomeController : Controller
    {
        int userky = 1;
        ApiOperation dbOpr;
        IConfiguration _iconfiguration;
        public HomeController(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
            string url = _iconfiguration.GetSection("APIConnectionStrings").GetSection("URI").Value;
            dbOpr = new ApiOperation(url);

        }
        public IActionResult Index()
        {
            List<HallDetails> hall = dbOpr.GetHallDetails(userky);
            
            return View(hall);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult Content(string submit,string selectedcity)
        {
            
            Details d = new Details();
            string img = "";
            if (selectedcity == "1")
            {
                img = "https://officesnapshots.com/wp-content/uploads/2017/02/004-700x467.jpg";
            }
            if (selectedcity == "2")
            {
                img = "http://www.arrowonswanston.com.au/uploads/9/8/1/8/98182264/img-5223_4_orig.jpg";
            }
            if (selectedcity == "3")
            {
                img = "http://bneahg.com.au/wp-content/uploads/2017/08/img-hotel-4-b.jpg";
            }
            d.img = img;
            d.header = selectedcity + " " + "Hall";
            d.h_id = selectedcity;
            ViewData["Message"] = ".";
            return View(d);

        }
        public IActionResult HallDetails(Details d)
        {
            ViewData["Message"] = ".";

            return View(d);
        }
        public IActionResult Payment()
        {
            ViewData["Message"] = ".";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
        [HttpPost]
        public JsonResult availabledate(string id)
        {
            Availability avb = dbOpr.GetHallAvbDetails(userky, id);
            List<BookingDetails> bdates = dbOpr.GetHallbookingDates(userky, id);
            avb.Bdetails = bdates;
            return Json(avb);
        }
    }
}
